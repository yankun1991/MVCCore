// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for adding XML formatters to MVC.
    /// </summary>
    public static class MvcXmlMvcCoreBuilderExtensions
    {
        /// <summary>
        /// Adds the XML DataContractSerializer formatters to MVC.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddXmlDataContractSerializerFormatters(this IMvcCoreBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            AddXmlDataContractSerializerFormatterServices(builder.Services);
            return builder;
        }

        /// <summary>
        /// Adds the XML Serializer formatters to MVC.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <returns>The <see cref="IMvcCoreBuilder"/>.</returns>
        public static IMvcCoreBuilder AddXmlSerializerFormatters(this IMvcCoreBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            AddXmlSerializerFormatterServices(builder.Services);
            return builder;
        }

        // Internal for testing.
        internal static void AddXmlDataContractSerializerFormatterServices(IServiceCollection services)
        {
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, MvcXmlDataContractSerializerMvcOptionsSetup>());
        }

        // Internal for testing.
        internal static void AddXmlSerializerFormatterServices(IServiceCollection services)
        {
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, MvcXmlSerializerMvcOptionsSetup>());
        }
    }
}

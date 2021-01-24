csharp
        /// <summary>
        /// Specifies that a type from a scanned assembly is registered if it implements an interface
        /// that closes the provided open generic interface type.
        /// </summary>
        /// <typeparam name="TLimit">Registration limit type.</typeparam>
        /// <typeparam name="TScanningActivatorData">Activator data type.</typeparam>
        /// <typeparam name="TRegistrationStyle">Registration style.</typeparam>
        /// <param name="registration">Registration to set service mapping on.</param>
        /// <param name="openGenericServiceType">The open generic interface or base class type for which implementations will be found.</param>
        /// <returns>Registration builder allowing the registration to be configured.</returns>
        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> AsClosedInterfacesOf<TLimit, TScanningActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration, Type openGenericServiceType) where TScanningActivatorData : ScanningActivatorData
        {
            if ((object)openGenericServiceType == null)
                throw new ArgumentNullException(nameof(openGenericServiceType));
            if (!openGenericServiceType.IsInterface)
                throw new ArgumentException("Generic type must be an interface", nameof(openGenericServiceType));
            return registration
                .Where(candidateType => candidateType.IsClosedTypeOf(openGenericServiceType))
                .As(candidateType =>
                    candidateType.GetInterfaces()
                        .Where(i => i.IsClosedTypeOf(openGenericServiceType))
                        .Select(t => (Service)new TypedService(t)));
        }
And then you can change your registration to 
csharp
builder.RegisterAssemblyTypes(assemblyType.Assembly)
    .AsClosedInterfacesOf(typeof(ICommandHandler<,>))
    .EnableInterfaceInterceptors()
    .InterceptedBy(typeof(LoggingInterceptor))
    .InterceptedBy(typeof(ExceptionHandlingInterceptor))
    .InstancePerLifetimeScope();

    public class InterfaceTypeDefinition
    {
        public InterfaceTypeDefinition(Type type)
        {
            Implementation = type;
            Interfaces = type.GetInterfaces();
        }
        /// <summary>
        /// The concrete implementation.
        /// </summary>
        public Type Implementation { get; private set; }
        /// <summary>
        /// The interfaces implemented by the implementation.
        /// </summary>
        public IEnumerable<Type> Interfaces { get; private set; }
        /// <summary>
        /// Returns a value indicating whether the implementation
        /// implements the specified open generic type.
        /// </summary>
        public bool ImplementsOpenGenericTypeOf(Type openGenericType)
        {
            return Interfaces.Any(i => i.IsOpenGeneric(openGenericType));
        }
        /// <summary>
        /// Returns the service type for the concrete implementation.
        /// </summary>
        public Type GetService(Type openGenericType)
        {
            return Interfaces.First(i => i.IsOpenGeneric(openGenericType))
                .GetGenericArguments()
                .Select(arguments => openGenericType.MakeGenericType(arguments))
                .First();
        }
    }

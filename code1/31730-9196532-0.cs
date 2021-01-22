        /// <summary>Determines whether a type, like IList&lt;int&gt;, implements an open generic interface, like
        /// IEnumerable&lt;&gt;. Note that this only checks against *interfaces*.</summary>
        /// <param name="candidateType">The type to check.</param>
        /// <param name="openGenericInterfaceType">The open generic type which it may impelement</param>
        /// <returns>Whether the candidate type implements the open interface.</returns>
        public static bool ImplementsOpenGenericInterface(this Type candidateType, Type openGenericInterfaceType)
        {
            Contract.Requires(candidateType != null);
            Contract.Requires(openGenericInterfaceType != null);
            return
                candidateType.IsGenericType && 
                (candidateType.Equals(openGenericInterfaceType) ||
                candidateType.GetGenericTypeDefinition().Equals(openGenericInterfaceType) ||
                candidateType.GetInterfaces().Any(i => i.ImplementsOpenGenericInterface(openGenericInterfaceType)));
        }

        /// <summary>
        /// [ <c>public static Type GetNullableType(Type TypeToConvert)</c> ]
        /// <para></para>
        /// Convert any Type to its Nullable&lt;T&gt; form, if possible
        /// </summary>
        /// <param name="TypeToConvert">The Type to convert</param>
        /// <returns>
        /// The Nullable&lt;T&gt; converted from the original type, the original type if it was already nullable, or null 
        /// if either <paramref name="TypeToConvert"/> could not be converted or if it was null.
        /// </returns>
        /// <remarks>
        /// To qualify to be converted to a nullable form, <paramref name="TypeToConvert"/> must contain a non-nullable value 
        /// type other than System.Void.  Otherwise, this method will return a null.
        /// </remarks>
        /// <seealso cref="Nullable&lt;T&gt;"/>
        public static Type GetNullableType(Type TypeToConvert)
        {
            // Abort if no type supplied
            if (TypeToConvert == null)
                return null;
            // If the given type is already nullable, just return it
            if (IsTypeNullable(TypeToConvert))
                return TypeToConvert;
            // If the type is a ValueType and is not System.Void, convert it to a Nullable<Type>
            if (TypeToConvert.IsValueType && TypeToConvert != typeof(void))
                return typeof(Nullable<>).MakeGenericType(TypeToConvert);
            // Done - no conversion
            return null;
        }

        /// <summary>
        /// [ <c>public static bool IsNullable(Type TypeToTest)</c> ]
        /// <para></para>
        /// Reports whether a given Type is nullable (Nullable&lt; Type &gt;)
        /// </summary>
        /// <param name="TypeToTest">The Type to test</param>
        /// <returns>
        /// true = The given Type is a Nullable&lt; Type &gt;; false = The type is not nullable, or <paramref name="TypeToTest"/> 
        /// is null.
        /// </returns>
        /// <remarks>
        /// This method tests <paramref name="TypeToTest"/> and reports whether it is nullable (i.e. whether it is either a 
        /// reference type or a form of the generic Nullable&lt; T &gt; type).
        /// </remarks>
        /// <seealso cref="GetNullableType"/>
        public static bool IsNullable(Type TypeToTest)
        {
            // Abort if no type supplied
            if (TypeToTest == null)
                return false;
            // If this is not a value type, it is a reference type, so it is automatically nullable
            //  (NOTE: All forms of Nullable<T> are value types)
            if (!TypeToTest.IsValueType)
                return true;
            // Report whether TypeToTest is a form of the Nullable<> type
            return TypeToTest.IsGenericType && typeof(Nullable<>).IsAssignableFrom(TypeToTest);
        }

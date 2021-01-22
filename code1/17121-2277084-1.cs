    /// <summary>
        /// Extension methods for <see cref="Type"/>.
        /// </summary>
        public static class TypeExtensions
        {
            /// <summary>
            /// Returns whether or not the specified type is <see cref="Nullable{T}"/>.
            /// </summary>
            /// <param name="type">A <see cref="Type"/>.</param>
            /// <returns>True if the specified type is <see cref="Nullable{T}"/>; otherwise, false.</returns>
            /// <remarks>Use <see cref="Nullable.GetUnderlyingType"/> to access the underlying type.</remarks>
            public static bool IsNullableType(this Type type)
            {
                if (type == null) throw new ArgumentNullException("type");
    
                return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof (Nullable<>));
            }
        }

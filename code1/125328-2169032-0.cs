        /// <summary>
        /// When given certain types such as those based on <see cref="T:Nullable`1"/>, <see cref="T:IEnumerable`1"/>,
        /// or <see cref="T:Array"/>, returns the element type associated with the input type.
        /// </summary>
        /// <remarks>
        /// For example, calling this method with Nullable(Of Boolean) would return Boolean. Passing Int32[] would
        /// return Int32, etc. All other types will return the input.
        /// </remarks>
        /// <param name="type">The a nullable type, array type, etc. whose element type you want to retrieve.</param>
        /// <returns>The type that the input type is based on.</returns>
        public static Type GetElementType( Type type )
        {
            ParameterValidation.ThrowIfNull( type, "type" );
            if ( type.IsGenericType ) {
                var typeArgs = type.GetGenericArguments( );
                if ( typeArgs.Length == 1 ) {
                    return typeArgs[0];
                }   // if
            }   // if
            if ( type.HasElementType ) {
                return type.GetElementType( );
            }   // if
            if ( type.IsEnum ) {
                return Enum.GetUnderlyingType( type );
            }   // if
            return type;
        }

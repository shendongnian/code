    public static class TypeExtensions
        {
            /// <summary>
            /// Check whether the type is complex or not
            /// eg: input type => PrimitiveType/String , output => false
            ///     input type => CustomComplexType, output => true
            ///     input type => Collection of CustomComplexType, output => true
            ///     input type => Collection of PrimitiveType/string output => true
            /// </summary>
            /// <param name="type"></param>
            /// <returns>true if the type is complex else false</returns>
            public static bool IsComplex(this Type type)
            {
                return !type.IsValueType && type != typeof(string);
            }
    
    
            /// <summary>
            /// eg: input type => PrimitiveType or String , output => false
            ///     input type => Collection of PrimitiveType/String output => false
            ///     input type => CustomComplexType, output => true
            ///     input type => Collection of CustomComplexType, output => true
            /// </summary>
            /// <param name="type"></param>
            /// <returns>
            /// Returns true if Complex array or Complex
            /// Returns false if Primitive array or Primitive
            /// </returns>
            public static bool IsCustomComplex(this Type type)
            {
                var elementType = type.GetCustomElementType();
                return elementType != null && elementType.IsComplex();
            }
    
            public static Type GetCustomElementType(this Type type, object value)
            {
                return value != null 
                    ? value.GetType().GetCustomElementType() 
                    : type.GetCustomElementType();
            }
    
            public static Type GetCustomElementType(this Type type)
            {
                return type.IsCollection()
                    ? type.IsArray
                        ? type.GetElementType()
                        : type.GetGenericArguments()[0]
                    : type;
            }
    
            /// <summary>
            /// Same as IsCustomComplex(this Type type) if value is not null
            /// then it will get type from the value
            /// else it will take get result from the type
            /// Mainly useful when ICollection property = new[] {};
            /// </summary>
            /// <param name="type"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public static bool IsCustomComplex(this Type type, object value)
            {
                return value != null
                    ? value.GetType().IsCustomComplex()
                    : type.IsCustomComplex();
            }
    
            /// <summary>
            /// Check whether the type is collection or not
            /// </summary>
            /// <param name="type"></param>
            /// <returns>Returns true if type stands for a collection else false</returns>
            public static bool IsCollection(this Type type)
            {
                var collectionTypeName = typeof(IEnumerable<>).Name;
                return (type.Name == collectionTypeName || type.GetInterface(typeof(IEnumerable<>).Name) != null ||
                        type.IsArray) && type != typeof(string);
            }
    
            public static bool HasDefaultConstructor(this Type type)
            {
                return type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null;
            }
    
        }

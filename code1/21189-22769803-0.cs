     /// <summary>
        /// returns the default value of a specified type
        /// </summary>
        /// <param name="type"></param>
        public static object GetDefault(this Type type)
        {
            return type.IsValueType ? (!type.IsGenericType ? Activator.CreateInstance(type) : type.GenericTypeArguments[0].GetDefault() ) : null;
        }

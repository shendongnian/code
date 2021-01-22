        /// <summary>
        /// Used to store TryParse converter methods
        /// </summary>
        private static readonly Dictionary<Type, MethodInfo> TypeConverters = new Dictionary<Type, MethodInfo>();
        /// <summary>
        /// Attempt to parse the input object to the output type
        /// </summary>
        /// <typeparam name="T">output type</typeparam>
        /// <param name="obj">input object</param>
        /// <param name="result">output result on success, default(T) on failure</param>
        /// <returns>Success</returns>
        public static bool TryParse<T>([CanBeNull] object obj, out T result)
        {
            result = default(T);
            try
            {
                switch (obj)
                {
                    // don't waste time on null objects
                    case null: return false;
                    
                    // if the object is already of type T, just return the value
                    case T val:
                        result = val;
                        return true;
                }
                // convert the object into type T via string conversion
                var input = ((obj as string) ?? obj.ToString()).Trim();
                if (string.IsNullOrEmpty(input)) return false;
                var type = typeof (T);
                Debug.WriteLine($"Info: {nameof(TryParse)}<{type.Name}>({obj.GetType().Name}=\"{input}\")");
                if (! TypeConverters.TryGetValue(type, out var method))
                {
                    // get the TryParse method for this type
                    method = type.GetMethod("TryParse",
                        new[]
                        {
                            typeof (string),
                            Type.GetType($"{type.FullName}&")
                        });
                    if (method is null)
                        Debug.WriteLine($"FAILED: Cannot get method for {type.Name}.TryParse()");
                    // store it so we don't have to do this again
                    TypeConverters.Add(type, method);
                }
                // have to keep a reference to parameters if you want to get the returned ref value
                var parameters = new object[] {input, null};
                if ((bool?) method?.Invoke(null, parameters) == true)
                {
                    result = (T) parameters[1];
                    return true;
                }                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }

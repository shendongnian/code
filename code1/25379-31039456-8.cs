    /// <summary>
    /// Class for doing argument checks
    /// </summary>
    public static class ArgumentCheck
    {
        
        /// <summary>
        /// Checks if a value is string or any other object if it is string
        /// it checks for nullorwhitespace otherwhise it checks for null only
        /// </summary>
        /// <typeparam name="T">Type of the item you want to check</typeparam>
        /// <param name="item">The item you want to check</param>
        /// <param name="nameOfTheArgument">Name of the argument</param>
        public static void IsNullorWhiteSpace<T>(T item, string nameOfTheArgument = "")
        {
            Type type = typeof(T);
            if (type == typeof(string) ||
                type == typeof(String))
            {
                if (string.IsNullOrWhiteSpace(item as string))
                {
                    throw new ArgumentException(nameOfTheArgument + " is null or Whitespace");
                }
            }
            else
            {
                if (item == null)
                {
                    throw new ArgumentException(nameOfTheArgument + " is null");
                }
            }
        }
    }
    

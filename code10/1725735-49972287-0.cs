    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks each string property of the given object to check if it contains the 
        /// search term. If any of those properties is a collection, we search that collection
        /// using the the IEnumarableExtensions Search
        /// </summary>
        /// <param name="inputObject"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static bool Contains(this object inputObject, string term)
        {
            var result = false;
            if (inputObject == null)
                return result;
            var properties = inputObject
                .GetType()
                .GetProperties();
            foreach (var property in properties)
            {
                // First check if the object is a string (and ensure it is not null)
                if (property != null && property.PropertyType == typeof(string))
                {
                    var propertyValue = (string)property.GetValue(inputObject, null);
                    result = propertyValue == null
                        ? false
                        : propertyValue.IndexOf(term, StringComparison.CurrentCultureIgnoreCase) >= 0;
                }
                // Otherwise, check if its a collection (we need to do this after the string check, 
                // as a string is technically a IEnumerable type
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    result = ((IEnumerable<object>)property.GetValue(inputObject, null)).Search(term).Count() > 0;
                }
                else
                {
                    var propertyValue = property.GetValue(inputObject, null);
                    result = propertyValue == null
                        ? false
                        : propertyValue.ToString().Contains(term);
                }
                if (result)
                    break;
            }
            return result;
        }
    }

        /// <summary>
        /// string.TryParse()
        /// 
        /// This generic extension method will take a string
        ///     make sure it is not null or empty
        ///     make sure it represents some type of number e.g. "123" not "abc"
        ///     It then calls the appropriate converter for the type of T
        /// </summary>
        /// <typeparam name="T">The type of the desired retrunValue e.g. int, float, byte, decimal...</typeparam>
        /// <param name="targetText">The text to be converted</param>
        /// <param name="returnValue">a populated value of the type T or the default(T) value which is likely to be 0</param>
        /// <returns>true if the string was successfully parsed and converted otherwise false</returns>
        public static bool TryParse<T>(this string targetText, out T returnValue )
        {
            bool returnStatus = false;
            returnValue = default(T);
            //
            // make sure the string is not null or empty and likely a number...
            // call whatever you like here or just leave it out - I would
            // at least make sure the string was not null or empty  
            //
            if ( ValidatedInputAnyWayYouLike(targetText) )
            {
                //
                // try to catch anything that blows up in the conversion process...
                //
                try
                {
                    var type = typeof(T);
                    var converter = TypeDescriptor.GetConverter(type);
                    if (converter != null && converter.IsValid(targetText))
                    {
                        returnValue = (T)converter.ConvertFromString(targetText);
                        returnStatus = true;
                    }
                }
                catch
                {
                    // just swallow the exception and return the default values for failure
                }
            }
            return (returnStatus);
        }
'''

        public static string FindandReplace(this string inputText, Dictionary<string, string> placeHolderValues)
        {
            if (!string.IsNullOrEmpty(inputText))
            {
                return placeHolderValues.Keys.Aggregate(inputText, (current, key) => current.Replace(key, placeHolderValues[key]));
            }
            else return inputText;
        }

    public static class ArrayEx
    {
    
        public static string JoinArray<T>(this T[] inputTypeArray, string separator)
        {
            string[] stringArray = new string[inputTypeArray.Length];
            for (int i = 0; i < inputTypeArray.Length; ++i)
            {
                stringArray[i] = System.Convert.ToString(inputTypeArray[i], System.Globalization.CultureInfo.InvariantCulture);
            }
            /*
            // SQL-Escape
            if (typeof(T) == typeof(string))
            {
                for (int i = 0; i < stringArray.Length; ++i)
                {
                    if (!string.IsNullOrEmpty(stringArray[i]))
                        stringArray[i] = stringArray[i].Replace("'", "''");
                }
            }
            */
            return string.Join(separator, stringArray);
        }
    }

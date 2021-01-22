        public static string ToStringNonLinqy<T>(this T[] array, string delimiter)
        {
            if (array != null)
            {
                // note: this code would likely be inefficient,
                // especially for long arrays.  For short arrays,
                // it might be more efficent than using a StringBuilder
                string[] values = new string[array.Length];
                for (int i = 0; i < values.Length; i++)
                    values[i] = array[i].ToString();
                return string.Join(delimiter, values);
            }
            else
            {
                return null;
            }
        }

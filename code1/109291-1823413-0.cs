        public static string ToStringNonLinqy<T>(this T[] array, string delimiter)
        {
            if (array != null)
            {
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

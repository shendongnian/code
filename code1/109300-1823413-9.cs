        public static string ToStringNonLinqy<T>(this T[] array, string delimiter)
        {
            if (array != null)
            {
                // edit: replaced my previous implementation to use StringBuilder
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                    builder.Append(array[i]);
                return builder.ToString()
            }
            else
            {
                return null;
            }
        }

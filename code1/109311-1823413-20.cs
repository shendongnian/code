        public static string ToStringNonLinqy<T>(this T[] array, string delimiter)
        {
            if (array != null)
            {
                // edit: replaced my previous implementation to use StringBuilder
                if (array.Length > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(array[0]);
                    for (int i = 1; i < array.Length; i++)
                    {
                        builder.Append(delimiter);
                        builder.Append(array[i]);
                    }
                    return builder.ToString()
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return null;
            }
        }

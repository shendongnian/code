        // convert an enumeration of one type into an enumeration of another type
        public static IEnumerable<TOut> Convert<TIn, TOut>(this IEnumerable<TIn> input, Func<TIn, TOut> conversion)
        {
            foreach (TIn value in input)
            {
                yield return conversion(value);
            }
        }
        // concatenate the strings in an enumeration separated by the specified delimiter
        public static string Delimit(this IEnumerable<string> input, string delimiter)
        {
            IEnumerator<string> enumerator = input.GetEnumerator();
            if (enumerator.MoveNext())
            {
                // create a StringBuilder initialized with the first element
                StringBuilder builder = new StringBuilder(enumerator.Current);
                // append the remaining elements separated by the delimiter
                while (enumerator.MoveNext())
                {
                    builder.Append(delimiter);
                    builder.Append(enumerator.Current);
                }
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        // a simplified utility function to use in our application code
        public static string ToString<T>(this T[] array, string delimiter)
        {
            if (array != null)
            {
                return array.Convert(i => i.ToString()).Delimit(delimiter);
            }
            else
            {
                return null;
            }
        }

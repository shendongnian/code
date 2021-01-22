        // convert an enumeration of one type into an enumeration of another type
        public static IEnumerable<TOut> Convert<TIn, TOut>(this IEnumerable<TIn> input, Func<TIn, TOut> conversion)
        {
            foreach (TIn value in input)
            {
                yield return conversion(value);
            }
        }
        // concatenate the strings in an enumeration separated by the specified delimiter
        public static string Delimit<T>(this IEnumerable<T> input, string delimiter)
        {
            IEnumerator<T> enumerator = input.GetEnumerator();
            if (enumerator.MoveNext())
            {
                StringBuilder builder = new StringBuilder();
                // start off with the first element
                builder.Append(enumerator.Current);
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
        // concatenate all elements
        public static string ToString<T>(this IEnumerable<T> input)
        {
            return ToString(input, string.Empty);
        }
        // concatenate all elements separated by a delimiter
        public static string ToString<T>(this IEnumerable<T> input, string delimiter)
        {
            return input.Delimit(delimiter);
        }
        // concatenate all elements, each one left-padded to a minimum length
        public static string ToString<T>(this IEnumerable<T> input, int minLength, char paddingChar)
        {
            return input.Convert(i => i.ToString().PadLeft(minLength, paddingChar)).Delimit(string.Empty);
        }

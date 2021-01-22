      /// <summary>
        /// From BReusable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="toStringFunc"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string ToJoinedString<T>(this IList<T> items, Func<int, T, string> toStringFunc, string seperator)
        {
    
            var sb = new StringBuilder();
            
            for (int i = 0; i < items.Count(); i++)
            {
                sb.Append((i != 0 ? seperator : String.Empty) + toStringFunc(i,items[i]));
               
            }
            return sb.ToString();
        }
    
        public static string ToStringFromCharArray(this IEnumerable<char> items)
        {
            return items.ToJoinedString(x => x.ToString(), string.Empty);
        }

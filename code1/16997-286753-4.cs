        public static T ToEnum<T>(this string str) where T : struct
        {
            return (T)Enum.Parse(typeof(T), str);
        }
        //DayOfWeek sunday =  "Sunday".ToEnum<DayOfWeek>(); 
        public static string ToString<T>(this IEnumerable<T> collection, string separator)
        {
            return ToString(collection, t => t.ToString(), separator);
        }
        public static string ToString<T>(this IEnumerable<T> collection, Func<T, string> stringElement, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.Append(stringElement(item));
                sb.Append(separator);
            }
            return sb.ToString(0, Math.Max(0, sb.Length - separator.Length));  // quita el ultimo separador
        }
        //new []{1,2,3}.ToString(i=>i*2, ", ")  --> "2, 4, 6"

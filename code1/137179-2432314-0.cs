        class Program
        {
        static void Main(string[] args)
        {
            List<string> strings = new List<string> { "hello", "world", "this", "is", "my", "list" };
            List<DateTime> dates = new List<DateTime> { DateTime.Now, DateTime.MinValue, DateTime.MaxValue };
            Console.WriteLine(ToCSVList(strings, (string s) => { return s.Length.ToString(); }));
            Console.WriteLine(ToCSVList(dates, (DateTime d) => { return d.ToString(); }));
            Console.ReadLine();
        }
        public static string ToCSVList<T, U>(T list, Func<U, String> f) where T : IList<U>
        {
            var sb = new StringBuilder(list.Count * 36 + list.Count);
            string delimiter = String.Empty;
            foreach (var document in list)
            {
                sb.Append(delimiter + f(document));
                delimiter = ",";
            }
            return sb.ToString();
        }
    }

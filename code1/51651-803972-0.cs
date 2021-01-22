    class Program
    {
        static void Main(string[] args)
        {
            // safe
            var firstOnly = GetList().First();
            // safe
            foreach (var item in GetList())
            {
                if(item == "2")
                    break;
            }
            // safe
            using (var enumerator = GetList().GetEnumerator())
            {
                for (int i = 0; i < 2; i++)
                {
                    enumerator.MoveNext();
                }
            }
            // unsafe
            var enumerator2 = GetList().GetEnumerator();
            for (int i = 0; i < 2; i++)
            {
                enumerator2.MoveNext();
            }
        }
        static IEnumerable<string> GetList()
        {
            using (new Test())
            {
                yield return "1";
                yield return "2";
                yield return "3";
            }
        }
    }
    class Test : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("dispose called");
        }
    }

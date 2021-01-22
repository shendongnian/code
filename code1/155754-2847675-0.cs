        static void Main(string[] args)
        {
            foreach (var x in new DataGet().GetData())
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
        public class DataGet
        {
            private List<string> _data = new List<string>() { "1", "2", "3", "4", "5" };
            private object _locker = new object();
            public IEnumerable<string> GetData()
            {
                lock (_locker)  //breakpoint 1
                {
                    foreach (string s in _data)
                    {
                        yield return s;
                    }
                } //breakpoint 2
            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> myList = new DataGetter().GetData();
            Console.WriteLine("start Getdata");
            foreach (var x in myList)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("end GetData");
            Console.ReadLine();
        }
        public class DataGetter
        {
            private List<string> _data = new List<string>() { "1", "2", "3", "4", "5" };
            private object _locker = new object();
            public IEnumerable<string> GetData()
            {
                lock (_locker)
                {
                    Console.WriteLine("Lock Taken");
                    foreach (string s in _data)
                    {
                        yield return s;
                    }
                }
                Console.WriteLine("Lock released");
            }
        }
    }

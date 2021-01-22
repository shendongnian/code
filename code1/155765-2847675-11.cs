        static void Main(string[] args)
        {
            object locker = new object();
            IEnumerable<string> myList1 = new DataGetter().GetData(locker, "List 1");
            IEnumerable<string> myList2 = new DataGetter().GetData(locker, "List 2");
            Console.WriteLine("start Getdata");
            foreach (var x in myList1)
            {
                Console.WriteLine("List 1 {0}", x);
                foreach(var y in myList2)
                {
                    Console.WriteLine("List 2 {0}", y);
                }
            }
            Console.WriteLine("end GetData");
            Console.ReadLine();
        }
        public class DataGetter
        {
            private List<string> _data = new List<string>() { "1", "2", "3", "4", "5" };
            
            public IEnumerable<string> GetData(object lockObj, string listName)
            {
                Console.WriteLine("{0} Starts", listName);
                lock (lockObj)
                {
                    Console.WriteLine("{0} Lock Taken", listName);
                    foreach (string s in _data)
                    {
                        yield return s;
                    }
                }
                Console.WriteLine("{0} Lock Released", listName);
            }
        }
    }

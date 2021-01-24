    namespace ConsoleApplication2
    {
        public delegate void OnAddEventHandler(object item);
        public class AddEventArgs : EventArgs
        {
            public object item { get; set; }
        }
        public class MyList<T> : List<T>
        {
            public event OnAddEventHandler OnAdd;
            public new void Add(T item)
            {
                base.Add(item);
                if (OnAdd != null)
                {
                    OnAdd(item);
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyList<string> lst = new MyList<string>();
                lst.OnAdd += (item) => {
                    Console.WriteLine("new item added: " + item);
                };
                lst.Add("test");
                Console.ReadLine();
            }
        }
    }

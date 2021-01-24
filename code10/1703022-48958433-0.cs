        class Program
    {
        static void Main(string[] args)
        {
            MonitorMemoryUsage();
            MonitorMemoryUsage();
            MonitorMemoryUsage();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void MonitorMemoryUsage()
        {
            DisplayMemoryAfterGc("Before creation");
            var demonstrator = new Demonstrator();
            DisplayMemoryAfterGc("After creation");
            if (demonstrator.Children != null && demonstrator.Children.Count > 0)
            {
                demonstrator.Children = null;
                demonstrator.Parents = null;
                demonstrator = null;
            }
            Console.WriteLine(demonstrator == null);
            DisplayMemoryAfterGc("After null");
        }
        private static void DisplayMemoryAfterGc(string eventType)
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            var totalMemory = GC.GetTotalMemory(true);
            Console.WriteLine(eventType + ":" + totalMemory);
        }
    }
    public class Demonstrator
    {
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
        public Demonstrator()
        {
            Parents = new List<Parent>();
            Children = new List<Child>();
            for (int i = 0; i < 10000; i++)
            {
                var parent = new Parent();
                Parents.Add(parent);
                Children.Add(parent._child1);
            }
        }
    }
    public class Parent
    {
        public Child _child1, _child2;
        void someFunc()
        {
            _child1 = new Child();
            _child2 = new Child();
            _child1.handle += parentHandle;
        }
        void parentHandle(Child sender)
        {
            Console.WriteLine("Sender is: " + sender.ToString());
        }
    }
    public class Child
    {
        public OnHandle handle;
        public delegate void OnHandle(Child sender);
        void someChildFunc()
        {
            handle(this);
        }
    }

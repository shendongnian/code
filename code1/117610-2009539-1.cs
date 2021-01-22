    class DataSource
    {
        public DataSource(string name) { this.name = name; }
        private readonly string name;
        ~DataSource() { Console.WriteLine("Collected: " + name); }
        
        public event EventHandler SomeEvent;
    }
    class DataListener
    {
        public DataListener(string name) { this.name = name; }
        private readonly string name;
        ~DataListener() { Console.WriteLine("Collected: " + name); }
        public void Subscribe(DataSource source)
        {
            source.SomeEvent += SomeMethodOnThisObject;
        }
        private void SomeMethodOnThisObject(object sender, EventArgs args) { }
    }
    static class Program
    {
        static void Main()
        {
            DataSource source1 = new DataSource("Source 1"),
                    source2 = new DataSource("Source 2");
            DataListener listener1 = new DataListener("Listener 1"),
                    listener2 = new DataListener("Listener 2");
            listener1.Subscribe(source1);
            listener2.Subscribe(source2);
            // now we'll release one source and one listener, and force a collect
            source1 = null;
            listener2 = null;
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers(); // source 1 gets collected, ONLY
            Console.WriteLine("Done");
            Console.ReadLine();
            GC.KeepAlive(source2); // prevents collection due to optimisation
            GC.KeepAlive(listener1); // prevents collection due to optimisation
        }
    }

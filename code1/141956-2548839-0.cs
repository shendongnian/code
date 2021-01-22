    public delegate void CallbackDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Queue<object> items = new Queue<object>();
            Processor processor = new Processor(items);
            Adder adder = new Adder(items, new CallbackDelegate(processor.CallBack));
            Thread addThread = new Thread(new ParameterizedThreadStart(adder.AddItem));
            object objectToAdd = new object();
            addThread.Start(objectToAdd);
        }
    }
    class Processor
    {
        Queue<object> items;
        public Processor(Queue<object> itemsArg)
        {
            items = itemsArg;
        }
        public void ProcessQueue()
        {
            lock (items)
            {
                while (items.Count > 0)
                {
                    object real = items.Dequeue();
                    // process real
                }
            }
        }
        public void CallBack()
        {
            Thread processThread = new Thread(ProcessQueue);
            processThread.IsBackground = true;
            processThread.Start();
        }
    }
    class Adder
    {
        Queue<object> items;
        CallbackDelegate callback;
        public Adder(Queue<object> itemsArg, CallbackDelegate callbackArg)
        {
            items = itemsArg;
            callback = callbackArg;
        }
        public void AddItem(object o)
        {
            lock (items) { items.Enqueue(o); }
            callback();
        }
    }

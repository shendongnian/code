    class SimpleLabelPrinter
    {
        public bool KeepProcessing { get; set; }
        public IPrinter Printer { get; set; }
        public SimpleLabelPrinter(IPrinter printer)
        {
            Printer = printer;
        }
        Queue<string> printQueue = new Queue<string>();
        public void AddPrintItem(string item)
        {
            printQueue.Enqueue(item);
        }
        public void ProcessQueue()
        {
            KeepProcessing = true;
            while (KeepProcessing)
            {
                while (printQueue.Count > 0)
                {
                    Printer.Print(printQueue.Dequeue());
                }
                Thread.CurrentThread.Join(2 * 1000); //2 secs
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SimpleLabelPrinter printer1 = new SimpleLabelPrinter(...);
            SimpleLabelPrinter printer2 = new SimpleLabelPrinter(...);
            Thread printer1Thread = new Thread(printer1.ProcessQueue);
            Thread printer2Thread = new Thread(printer2.ProcessQueue);
            //...
            printer1.KeepProcessing = false;  //let the thread run its course...
            printer2.KeepProcessing = false;  //let the thread run its course...
        }
    }

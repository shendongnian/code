    // You will not need this class, if you always want a single string result.
    class PrinterData
    {
        public string Value { get; set; }
        // More properties?
    }
    class Printer
    {
        public Printer<T>(IEnumerable<T> list, Func<T, PrinterData> func)
        {
            foreach (T item in list)
            {
                PrinterData data = func(item);
                // Do something with the data.
            }
        }
    }

    class Printer
    {
        public Printer(IEnumerable<IPrintable> list)
        {
            foreach (var enumerable in list)
            {
                enumerable.Print();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<object> list = new GenericList<object>();
            // Add items to list.
            list.AddHead("some string here");
            list.AddHead(DateTime.Today.ToLongDateString());
            list.AddHead(13);
            list.AddHead(13.005);
            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }
            // Enumerate list.
            foreach (object i in list)
            {
                Console.WriteLine(i + " " + i.GetType());
            }
            Console.WriteLine("\nDone");
        }
    }

        static void Main()
        {
            var list = new LinkedList<object>();
            list.AddLast("My string");
            list.AddLast(1.5);
            list.AddLast(2);
            list.AddLast(true);
            var en = list.GetEnumerator();
            while (en.MoveNext())
                Console.WriteLine(en.Current);
            Console.ReadKey();
        }

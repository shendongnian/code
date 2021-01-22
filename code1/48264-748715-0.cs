        private static System.Collections.SortedList list = new System.Collections.SortedList();
        static void Main(string[] args)
        {
            list.Add("AAA" , "AAA");
            list.Add("AAB", "AAB");
            list.Add("AAC", "AAC");
            list.Add("ACC", "ACC");
            list.Add("ADA", "ADA");
            Console.WriteLine("List before");
            for (int j = 0; j < list.Count ; j++)
            {
                Console.WriteLine(list.GetByIndex(j));
            }
            list.Add("ABB","ABB");
            Console.WriteLine(list.IndexOfKey("ABB"));
            for (int j = 0; j < list.Count; j++)
            {
                Console.WriteLine(list.GetByIndex(j));
            }
            Console.ReadLine();
        }

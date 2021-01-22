        static void Main(string[] args)
        {
            ListBox sortedList = new ListBox();
            sortedList.Sorted = true;
            sortedList.Items.Add("foo");
            sortedList.Items.Add("bar");
            sortedList.Items.Add(true);
            sortedList.Items.Add(432); 
           
            foreach (object o in sortedList.Items)
            {
                Console.WriteLine(o);
            }
            Console.ReadKey();
        }

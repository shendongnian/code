            var list = new List<int>();
            list.Add( 2);
            list.Add( 1);
            list.Add( 3);
            Console.WriteLine("Using Linq OrderBy");
            foreach (int i in list.OrderBy(i=>i))
                Console.WriteLine(i);
            Console.WriteLine("Using List.Sort()");
            list.Sort();
            foreach (int i in list)
                Console.WriteLine(i);

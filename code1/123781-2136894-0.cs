            var list = new LinkedList<string>
                (new[] {"cat", "dog", "frog", "antelope", "gazelle"});
            var item = list.Last;
            do
            {
                Console.WriteLine(item.Value);
                item = item.Previous;
            }
            while (item != null);
            Console.ReadKey();

            LinkedList<string> list = new LinkedList<string>
                (new[] {"cat", "dog", "frog", "antelope", "gazelle"});
            LinkedListNode<string> item = list.Last;
            do
            {
                Console.WriteLine(item.Value);
                item = item.Previous;
            }
            while (item != null);
            Console.ReadKey();

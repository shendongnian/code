            Dictionary<int, int> elementCounts = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                int element = array[i];
                if (elementCounts.ContainsKey(element))
                    elementCounts[element]++;
                else
                    elementCounts.Add(element, 1);
            }
            
            Console.WriteLine("How many same elements?");
            foreach(KeyValuePair<int,int> count in elementCounts)
            {
                Console.WriteLine("Element: {0} Count: {1}", count.Key, count.Value);
            }

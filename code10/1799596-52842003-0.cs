            var results = new List<int>();
            for (int i = 1; i < n + 1; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    results.Add(i);
                }
            }
            Console.Write(string.Join(", ", results));
            Console.Read();

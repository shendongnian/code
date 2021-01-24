            string[] words = { "India", "England", "America", "China", "Australia" };
            string[] Ascending =  words.OrderBy(c => c).Select(c=>c).ToArray(); // Ascending order
            string[] Descending = words.OrderByDescending(c => c).Select(c => c).ToArray(); // Ascending order
            foreach (var item in Ascending)
            {
                Console.WriteLine(item);
            }
            foreach (var item in Descending)
            {
                Console.WriteLine(item);
            }

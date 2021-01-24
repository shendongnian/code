    public static void methodSort()
        {
            Dictionary<string, int> colorRank = new Dictionary<string, int>();
            //Code to fill the dictionary.
            colorRank.Add("bla2", 10);
            colorRank.Add("bla1", 1);
            colorRank.Add("bla3", 11);
            colorRank.Add("blay", 5);
            colorRank.Add("blay1", 10);
            var result = colorRank.OrderByDescending(i => i.Value).ThenBy(i => i.Key);
            
            foreach (var v in result)
            {
                Console.WriteLine($"{v.Key} {v.Value}");
            }
            /* Output
               bla3 11
               bla2 10
               blay1 10
               blay 5
               bla1 1
             */
        }

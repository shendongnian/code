    class Program
    {
        static void Main(string[] args)
        {
            List<string> uppers = new List<string>();
            uppers.Add("A");
            uppers.Add("B");
            List<string> lowers = new List<string>();
            lowers.Add("a");
            lowers.Add("b");
            List<string> combinedUppers = GetCombinedItems(uppers);
            List<string> combinedLowers = GetCombinedItems(lowers);
            List<string> combinedUppersLowers = GetCombinedList(combinedUppers, combinedLowers);
            foreach (string combo in combinedUppersLowers)
            {
                Console.WriteLine(combo);
            }
            Console.Read();
        }
        static private List<string> GetCombinedItems(List<string> list)
        {
            List<string> combinedItems = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                combinedItems.Add(list[i]);
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] != list[j])
                    {
                        combinedItems.Add(String.Format("{0}{1}", list[i], list[j]));
                    }
                }
            }
            return combinedItems;
        }
        static private List<string> GetCombinedList(List<string> list1, List<string> list2)
        {
            List<string> combinedList = new List<string>();
            for (int i = 0; i < list1.Count; i++)
            {
                combinedList.Add(list1[i]);
                for (int j = 0; j < list2.Count; j++)
                {
                    combinedList.Add(String.Format("{0}{1}", list1[i], list2[j]));
                }
            }
            for (int i = 0; i < list2.Count; i++)
            {
                combinedList.Add(list2[i]);
                for (int j = 0; j < list1.Count; j++)
                {
                    combinedList.Add(String.Format("{0}{1}", list2[i], list1[j]));
                }
            }
            return combinedList;
        }
    }

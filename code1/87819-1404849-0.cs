            static void Main(string[] args)
            {
                List<int> set1 = new List<int>() { 1, 2, 3 };
                List<int> set2 = new List<int>() { 4, 5, 6 };
    
                List<int> set3 = new List<int>(Combine(set1, set2));
            }
    
            private static IEnumerable<T> Combine<T>(IEnumerable<T> list1, IEnumerable<T> list2)
            {
                foreach (var item in list1)
                {
                    yield return item;
                }
    
                foreach (var item in list2)
                {
                    yield return item;
                }
            }

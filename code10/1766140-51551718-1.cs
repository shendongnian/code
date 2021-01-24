    static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 9 };
            int[] b = { 4, 7, 2 };
            InsertElements(a, b, 3, 2);
        }
        private static void InsertElements(int[] arr1, int[] arr2, int x, int n)
        {
            var listOfArr1 = arr1.ToList();
            var itemsToInsert = arr2.Take(n);
            var itemsToAdd = arr2.Skip(n);
            var pos = x - 1;
            foreach (var item in itemsToInsert)
            {
                listOfArr1.Insert(pos, item);
                pos++;
            }
            listOfArr1.AddRange(itemsToAdd);
            var result = listOfArr1.ToArray();
        }

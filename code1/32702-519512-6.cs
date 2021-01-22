    static void Main(string[] args)
    {
        List<int> originalList = new List<int>(5);
        Random random = new Random();
        for(int i = 0; i < 5; i++)
        {
            originalList.Add(random.Next(1, 100));
            Console.WriteLine("List[{0}] = {1}", i, originalList[i]);
        }
        List<int> deepCopiedList = GenericCopier<List<int>>.DeepCopy(originalList);
        for (int i = 0; i < 5; i++)
            Console.WriteLine("deepCopiedList[{0}] value is {1}", i, deepCopiedList[i]);
    }

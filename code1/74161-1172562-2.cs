    [Benchmark]
    public static void NativeForLoop()
    {
        List<string> Fruit = new List<String> { "Apple", "Orange", "Kiwi" };
        foreach (string FruitName in Fruit) {
            Work++;
        }
    }
    [Benchmark]
    public static void ListDotForEach()
    {
        List<string> Fruit = new List<String> { "Apple", "Orange", "Kiwi" };
        Fruit.ForEach((s)=>Work++);
    }
    

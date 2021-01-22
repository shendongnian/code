    var list = new List<int>(Enumerable.Range(1, 10));
    Console.WriteLine("Before:");
    list.ForEach(i => Console.WriteLine(i));
    list.RemoveAll(i => i > 5);
    Console.WriteLine("After:");
    list.ForEach(i => Console.WriteLine(i));

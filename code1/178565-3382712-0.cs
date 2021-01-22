    static void Main(string[] args)
    {
        SomeMethod();
    }
    private static void SomeMethod()
    {
        Action<int> action = (num) => Console.WriteLine(num);
      
        Enumerable.Range(1,10).ToList().ForEach(action);
        Console.ReadKey();
    } 

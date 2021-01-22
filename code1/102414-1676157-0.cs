    class Other
    {
        public void Stuff()
        { Console.WriteLine("stuff"); }
    }
    static void Main(string[] args)
    {
        var constructor = typeof(Other).GetConstructor(new Type[0]);
        var obj = constructor.Invoke(null);
        var method = typeof(Other).GetMethods().First();
        Func<object, object[], object> delegate = method.Invoke;
        delegate.BeginInvoke(obj, null, null, null);
        Console.ReadLine();
    }

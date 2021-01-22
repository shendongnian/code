    static void Main()
    {
    Observable.Interval(TimeSpan.FromSeconds(10)).Subscribe(t => Console.WriteLine("I am called... {0}", t));
    
    for (; ; ) { }
    }

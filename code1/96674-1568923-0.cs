    static void Main(string[] args)
    {
        DoThing();
        GC.Collect();
        Thread.Sleep(5000);
    }
    
    
    static void DoThing()
    {
        new System.Threading.Timer(x => { Console.WriteLine("Here"); },
                null,  
                TimeSpan.FromSeconds(1), 
                TimeSpan.FromMilliseconds(-1));
    }

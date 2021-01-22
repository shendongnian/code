    static void Main()
    {
     Thread t = new Thread(new ThreadStart(some delegate here));
     t.Start();
     Console.WriteLine("foo");
     t.Join()
     Console.WriteLine("foo2");
    }

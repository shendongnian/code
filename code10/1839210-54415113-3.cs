    public delegate void D(int i, int b);
    
    public void Main(string[] args) 
    {        
        //valid, lambda expression will be converted to compatible delegate instance
        D f1 = (int a, int b) => Console.WriteLine("Delegate invoked...");
        f1(3, 4);
        
        //INVALID, lambda expression will be converted to incompatible delegate instance
        D f2 = () => Console.WriteLine("Delegate invoked...");
        f2(3, 4);
        //valid, assigning delegate with compatible signature
        D f3 = delegate(int i, int j) { Console.WriteLine("Delegate invoked..."); };
        f3(3, 4);
        
        //INVALID, assigning delegate with incompatible signature
        D f4 = delegate() { Console.WriteLine("Delegate invoked..."); };
        f4(3, 4);
        
        //valid, it will be automatically compiled to compatible delegate instance which accepts (int, int)
        D f5 = delegate { Console.WriteLine("Delegate invoked..."); };
        f5(3, 4);
    }

    public delegate void QueuedMethod();
    
    static void Main(string[] args)
    {
        methodQueue(delegate(){methodOne( 1, 2 );});
        methodQueue(delegate(){methodTwo( 3, 4 );});
    }
    
    static void methodOne (int x, int y)
    {
    
    }
    
    static void methodQueue (QueuedMethod parameter)
    {
        parameter(); //run the method
        //...wait
        //...execute the parameter statement
    }

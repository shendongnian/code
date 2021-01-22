    static void foo(SomeObject so)
    {
        so.x = 1;
        so = null;
    }
    
    static void bar(ref SomeObject so)
    {
        so.x = 1;
        so = null;
    }
    
    SomeObject so1 = new SomeObject(); 
    foo(so1); 
    Console.write(so1.x); // will print 1 
    bar(so1); 
    Console.write(so1.x); // crash

    static void A()
    {
    	C();
    }
    static void C()
    {
    	StackTrace st = new StackTrace();
    	Console.WriteLine(st.GetFrame(1).GetMethod()); // prints "Void A()"
    }

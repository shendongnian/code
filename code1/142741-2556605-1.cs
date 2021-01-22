    public static void myFunction1(int a, int b, int c, string d)
    {
    	//dostuff
    	someoneelsesfunction(c, d);
    	//dostuff2
    }
    
    public static void myFunction2(int a, int b, int c, Stream d)
    {
        string str = d.ReadEntireString(); // no such method, but basically
            // whatever you need to do to read the string out of the stream
        myFunction1(a, b, c, str);    	
    }

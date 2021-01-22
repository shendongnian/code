    using System;
    delegate int SampleDelagate ();
    class MainClass
    {
	    public static void Main ()
	   {
		    SampleDelagate del1 = new SampleDelagate (Method1);
		    SampleDelagate del2 = new SampleDelagate (Method2);
		    SampleDelagate del3 = new SampleDelagate (Method3);
		    SampleDelagate del4 = del1 + del2 + del3;
		    int ValueReturned = del4 ();
		    //Del4 invokes Del1, Del2, Del3 in the same order. Here the return type is int. So the return of last delegate del3 is returned. Del3 points to Method3. So returned value is 3.
		    Console.WriteLine (ValueReturned);
		    //Output: 3
	    }
	    public static int Method1 ()
	    {
		    return 1;
	    }
	    public static int Method2 ()
	    {
		    return 2;
	    }
	    public static int Method3 ()
	    {
		    return 3;
	    }
    }

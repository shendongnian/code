    using System;
    delegate void SampleDelegate ();
    class MainClass
    {
	    public static void Main ()
	    {
		    SampleDelegate del = new SampleDelegate (Message1);		    //Declares del and initializes it to point to method Message1
		    del += Message2;										//Now method Message2 also gets added to del. Del is now pointing to two methods, Message1 and Message2. So it is now a MultiCast Delegate
		    del += Message3;										//Method Message3 now also gets added to del
		    del ();													//Del invokes Message1, Message2 and Message3 in the same order as they were added
		    /*
		    Output:
		    This is Message1
		    This is Message2
		    This is Message3
		    */
		    del -= Message1;										//Method     Message1 is now removed from Del. It no longer points to Message1
			    													//Del invokes the two remaining Methods Message1 and Message2 in the same order
		    del ();
		    /*
		    New Output:
		    This is Message2
		    This is Message3
		    */
		    del += Message4;										//Method Message4 gets added to Del. The three Methods that Del oints to are in the order 1 -> Message2, 2 -> Message3, 3 -> Message4
			    													//Del invokes the three methods in the same order in which they are present.
		    del ();
		    /*
		    New Output:
		    This is Message2
		    This is Message3
		    This is Message4
		    */
	    }
	    public static void Message1 ()
	    {
		    Console.WriteLine ("This is Message1");
	    }
	    public static void Message2 ()
	    {
		    Console.WriteLine ("This is Message2");
	    }
	    public static void Message3 ()
	    {
		    Console.WriteLine ("This is Message3");
	    }
	    public static void Message4 ()
	    {
		    Console.WriteLine ("This is Message4");
	    }
    }

    using System;
    delegate void SampleDelegate ();	//A delegate with 0 argument and void     return type is declared
    class MainClass
    {
	    public static void Main ()
	    {
		    SampleDelegate Del1 = new SampleDelegate (Message1);		 //Del1 declared which points to function Message1
		    SampleDelegate Del2 = new SampleDelegate (Message2);		//Del2 declared which points to function Message2
		    SampleDelegate Del3 = new SampleDelegate (Message3);		//Del3 declared which points to function Message3
		    SampleDelegate Del4 = Del1 + Del2 + Del3;					//Del4 declared which points to function Message4
		    //Del4 is then initialized as sum of Del1 + Del2 + Del3
		    Del4 ();		//Del4 is invoked;
		    //Del4 in turn invokes Del1, Del2 and Del3 in the same order they were initialized to Del4
		    //Del1, Del2, Del3 in turn invokes their respective functions to which they point to
		    //The three functions Message1, Message2 and Message3 gets executed one after another
	    }
            //Output:
            //This is message 1
            //This is message 2
            //This is message 3
            Del4 - Del1;	//Removes Del1 from Del4
            Del4();           
            //New Output:
            //This is message 2
            //This is message 3
            Del4 + Del1;	//Again adds Del1 to Del4
            Del4();
		    //New Output:
		    //This is message 1
            //This is message 2
            //This is message 3
	    public static void Message1 ()		//First sample function matching delegate signature
	    {
		    Console.WriteLine ("This is message 1");
	    }
	    public static void Message2 ()		//Second sample function
	    {
		     Console.WriteLine ("This is message 2");
	    }
	    public static void Message3 ()		//Third sample function
	    {
		    Console.WriteLine ("This is message 3");
	    }
    }

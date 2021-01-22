    using System;
    delegate void SampleDelegate (ref int SampleReferenceParameter);
    class MainClass
    {
	    public static void Main ()
	    {
		    SampleDelegate del1, del2, del3, del4;
		    del1 = new SampleDelegate (SampleMethodOne);
		    del2 = new SampleDelegate (SampleMethodTwo);
		    del3 = new SampleDelegate (SampleMethodTwo);
		    del4 = del1 + del2 + del3 - del3;
		    int SampleReferenceParameterValue = 0;
		    del4 (ref SampleReferenceParameterValue);
		    Console.WriteLine (SampleReferenceParameterValue); 
	    }
	    public static void SampleMethodOne (ref int SampleReferenceParameter)
	    {
		    SampleReferenceParameter = 1;
	    }
	    public static void SampleMethodTwo (ref int SampleReferenceParameter)
	    {
		    SampleReferenceParameter = 2;
	    }
	    public static void SampleMethodThree (ref int SampleReferenceParameter)
	    {
		    SampleReferenceParameter = 3;
	    }
    }
    /*
    Here del4 is first set as sum of del1, del2 and del3. Then del3 is subtracted from del4. So del4 now has del1, del2.
    When del4 is invoked, first del1 and then del2 is invoked.
    del1 sets reference parameter to 1. del2 sets reference parameter to 2.
    But since del2 is called last final value of reference parameter is 2
    */

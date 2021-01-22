	// This example demonstrates the String.Contains() method
	using System;
	class Sample 
	{
	    public static void Main() 
	    {
	    string s1 = "The quick brown fox jumps over the lazy dog";
	    string s2 = "fox";
	    bool b;
	    b = s1.Contains(s2);
	    Console.WriteLine("Is the string, s2, in the string, s1?: {0}", b);
	    }
	}
	/*
	This example produces the following results:
	Is the string, s2, in the string, s1?: True
	*/

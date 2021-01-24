    using System;
    static class X
    {
    	public static R Select<A, R>(this A item, Func<A, R> selector) =>
          selector(item);
    	public static R SelectMany<A, B, R>(this A item, Func<A, B> toB, Func<A, B, R> toR) =>
          toR(item, toB(item));
    }
    public class P
    {
    	public static void Main()
    	{
    		string myString = "hello";
    		string result = from s in myString
    			            from b in s + "goodbye"
    			            select b.ToUpper() + " " + s;
    		Console.WriteLine(result);
    	}
    }

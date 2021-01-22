    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		// value type
    		Console.WriteLine(1.IsDefault());
    		Console.WriteLine(0.IsDefault());
    
    		// reference type
    		Console.WriteLine("test".IsDefault());
    		// null must be cast to a type
    		Console.WriteLine(((String)null).IsDefault());
    	}
    }
    
    // The type cannot be generic
    public static class TypeHelper
    {
    	// I made the method generic instead
    	public static bool IsDefault<T>(this T val)
    	{
    		return EqualityComparer<T>.Default.Equals(val, default(T));
    	}
    }

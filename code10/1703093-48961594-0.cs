    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var paths = @"C:\Users\user\Desktop\TESTING\path1;C:\Users\user\Desktop\TESTING\path5;C:\Users\user\Desktop\TESTING\path1;C:\Users\user\Desktop\TESTING\path6;C:\Users\user\Desktop\TESTING\path1;C:\Users\user\Desktop\TESTING\path3;C:\Users\user\Desktop\TESTING\path1;C:\Users\user\Desktop\TESTING\path3;";
    		
    		var cleaned = string.Join(";", new HashSet<string>(paths.Split(';')));
    		
    		Console.WriteLine(cleaned);
    	}
    }

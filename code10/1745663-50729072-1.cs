    // mySource.cs
    using System;
    
    internal class Program
    {
    	static void Main()
    	{
    		Console.WriteLine("Hello from mySource!");
    		Console.ReadLine();
    	}
    }
    
    public class Command
    {
    	public void SayHello()
    	{
    		Console.WriteLine("Hello (Command)");
    	}
    }

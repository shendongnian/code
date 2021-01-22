    using System;
    using Blixt.Utilities;
    
    namespace Blixt.Playground
    {
    	[Flags]
    	public enum Colors : byte
    	{
    		Black = 0,
    		Red = 1,
    		Green = 2,
    		Blue = 4
    	}
    
    	[Flags]
    	public enum Tastes : byte
    	{
    		Nothing = 0,
    		Sour = 1,
    		Sweet = 2,
    		Bitter = 4,
    		Salty = 8
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Colors c = Colors.Blue | Colors.Red;
    			Console.WriteLine("Green and blue? {0}", c.HasFlags(Colors.Green | Colors.Red));
    			Console.WriteLine("Blue?           {0}", c.HasFlags(Colors.Blue));
    			Console.WriteLine("Green?          {0}", c.HasFlags(Colors.Green));
    			Console.WriteLine("Red and blue?   {0}", c.HasFlags(Colors.Red | Colors.Blue));
    			
    			// Compilation error:
    			//Console.WriteLine("Sour?           {0}", c.HasFlags(Tastes.Sour));
    
    			Console.WriteLine("Press any key to exit...");
    			Console.ReadKey(true);
    		}
    	}
    }

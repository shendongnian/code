    using System;
    using System.Linq; // !! important
    public class Program
    {
    	public static void Main()
    	{
    		string phrase = Console.ReadLine();
    		int wordIndex = Convert.ToInt32(Console.ReadLine());
    		var result = phrase.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
    			.Skip(wordIndex - 1)
    			.FirstOrDefault(); 
    		Console.WriteLine(result ?? "N/A");
    	}
    }

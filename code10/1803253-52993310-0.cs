        using System;
        using System.Linq;
        using System.Collections.Generic;
        public class Program
        {
	        public static void Main()
	        {
		         string input = Console.ReadLine();
		
		         var chars = input.ToCharArray();
		
		         var uniqueChars = chars.Where(i=>i!= ' ').Distinct();
				
		         var dictionary = new Dictionary<char,int>();
		
		         foreach(var ch in uniqueChars)
		         		  dictionary.Add(ch ,chars.Where(i => i == ch).Count());
		
		         foreach(var keyValue in dictionary)
		                  Console.WriteLine($"{keyValue.Key} : {keyValue.Value}");
		
	         }
        }

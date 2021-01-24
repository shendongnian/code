    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] words = new string[] {
    			"I", "need", "to", "create", "a", "method", "which", "takes", "string[]", 
    			"and", "only", "returns", "words", "that", "are", "5", "letters", "or", "shorter",
    			"aren't"
    		};
    		
    		Console.WriteLine(string.Join(", ", Get5LetterWords(words)));
    		
    	}
    	
    	public static string[] Get5LetterWords(string[] words)
    	{
    		Regex rgx = new Regex("[^a-zA-Z]");
    		List<string> _5LetterWords = new List<string>();
    		for (int i = 0; i < words.Length; i++)
    		{
    			string word = rgx.Replace(words[i], "");
    			if (!string.IsNullOrEmpty(word) && word.Length <=5 )
    			{
    				_5LetterWords.Add(words[i]);
    			}
    			
    		}
    			
    		return _5LetterWords.ToArray();
    	}
    }

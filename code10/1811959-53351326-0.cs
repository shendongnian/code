    public void DeleteWordsFromText(string text, string[] wordsToDelete, char[] separators)
    {
        Console.WriteLine(text);
        foreach (string word in wordsToDelete)
        {
			foreach(char separator in separators)
			{
            	text = text.Replace(word + separator, String.Empty);
			}
        }
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine(text);
    }

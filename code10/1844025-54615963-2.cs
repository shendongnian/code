	string MergeWords(string word1, string word2)
	{
        var index = Enumerable
                     .Range(0, word2.Length+1)
                     .First(i => word1.EndsWith(word2.Substring(0, word2.Length - i)));
        return word1 + word2.Substring(word2.Length - index);
    }

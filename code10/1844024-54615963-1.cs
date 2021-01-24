	string MergeWords(string word1, string word2)
	{
	    for (int i = word2.Length; i > 0; i--)
	    {
	        if (word1.EndsWith(word2.Substring(0, i)))
	        {
	            return word1 + word2.Substring(i);
	        }
	    }
	    return word1 + word2;
	}

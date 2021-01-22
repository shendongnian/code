    string[] words = news.Split(' ');
    
    StringBuilder builder = new StringBuilder();
    foreach (string word in words)
    {
        if (word.Length > 1)
        {
           if (builder.ToString().Length ==0)
           {
               builder.Append(word);
           }
           else
           {
               builder.Append(" " + word);
           }
        }
    }
    
    string result = builder.ToString();

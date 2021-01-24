    public string Longest
    {
        get
        {
            int longestLength = 0;
            string longestWord = string.Empty;
            for (Node i = Head; i != null; i = i.Next)
            {
                if (i.Text.Length > longestLength)
                {
                    longestLength = i.Text.Length;
                    longestWord = i.Text;
                }
            }
    
            return longestWord;
        }
    }

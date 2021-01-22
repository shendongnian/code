    public static class WordCount
    {
        public static int Count(string text)
        {
            int wordCount = 0;
            text = text.Trim();// trim white spaces
 
            if (text == ""){return 0;} // end if empty text
            foreach (string word in text.Split(' ')) // or use any other char(instead of empty space ' ') that you consider a word splitter 
            wordCount++;
            return wordCount;
        }
    }

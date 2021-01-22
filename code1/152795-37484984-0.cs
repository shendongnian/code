    public static string TruncateText(string strText, int intLength)
    {
        if (!(string.IsNullOrEmpty(strText)))
        {                                
            // split the text.
            var words = strText.Split(' ');
            // calculate the number of words
            // based on the provided characters length 
            // use an average of 7.6 chars per word.
            int wordLength = Convert.ToInt32(Math.Ceiling(intLength / 7.6));
            // if the text is shorter than the length,
            // display the text without changing it.
            if (words.Length <= wordLength)
                return strText.Trim();                
            // put together a shorter text
            // based on the number of words
            return string.Join(" ", words.Take(wordLength)) + " ...".Trim();
        }
            else
            {
                return "";
            }            
        }

     public string GetNumberOfWord(string description, int length)
        {
            var biggestWord = 50;
            var elipse = "[...]";
            if (description == "undefined")
            {
                return description;
            }
            var truncatedText = description.Substring(0, length + biggestWord);
            while(truncatedText.Length > length - elipse.Length)
            {
                var lastSpace = truncatedText.LastIndexOf(" ");
                if(lastSpace == -1)
                {
                    break;
                }
                truncatedText = truncatedText.Substring(0, lastSpace).Replace("/[!,.?]$/","");
            }
            return truncatedText + elipse;
        }
 

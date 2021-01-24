    public static string GetPlainTextFromHTML(string inputText)
        {
            // Extracted plain text
            var plainText = string.Empty;
            if(string.IsNullOrWhiteSpace(inputText))
            {
                return plainText;
            }
            var htmlNote = new HtmlDocument();
            htmlNote.LoadHtml(inputText);
            var nodes = htmlNote.DocumentNode.ChildNodes;
            if(nodes == null)
            {
                return plainText;
            }
            StringBuilder innerString = new StringBuilder();
            // Replace <p> with new lines
            foreach (HtmlNode node in nodes) 
            {
                innerString.Append(node.InnerText);
                innerString.Append("\\n");
            }
            plainText = innerString.ToString();
            return plainText;
        }
  
   

    namespace UmbracoUtilities
    {
        public class Text
        {
          /// <summary>
          /// Return the first n words in the html
          /// </summary>
          /// <param name="html"></param>
          /// <param name="n"></param>
          /// <returns></returns>
          public static string Words(string html, int n)
          {
            string words = html, n_words;
    
            words = StripHtml(html);
            n_words = GetNWords(words, n);
    
            return n_words;
          }
    
    
          /// <summary>
          /// Returns the first n words in text
          /// Assumes text is not a html string
          /// http://stackoverflow.com/questions/13368345/get-first-250-words-of-a-string
          /// </summary>
          /// <param name="text"></param>
          /// <param name="n"></param>
          /// <returns></returns>
          public static string GetNWords(string text, int n)
          {
            StringBuilder builder = new StringBuilder();
    
            //remove multiple spaces
            //http://stackoverflow.com/questions/1279859/how-to-replace-multiple-white-spaces-with-one-white-space
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");
            IEnumerable<string> words = cleanedString.Split().Take(n + 1);
    
            foreach (string word in words)
              builder.Append(" " + word);
    
            return builder.ToString();
          }
    
    
          /// <summary>
          /// Returns a string of html with tags removed
          /// </summary>
          /// <param name="html"></param>
          /// <returns></returns>
          public static string StripHtml(string html)
          {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
    
            var root = document.DocumentNode;
            var stringBuilder = new StringBuilder();
    
            foreach (var node in root.DescendantsAndSelf())
            {
              if (!node.HasChildNodes)
              {
                string text = node.InnerText;
                if (!string.IsNullOrEmpty(text))
                  stringBuilder.Append(" " + text.Trim());
              }
            }
    
            return stringBuilder.ToString();
          }
    
    
    
        }
    }

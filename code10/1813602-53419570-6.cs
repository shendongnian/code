      using using System.Text.RegularExpressions;
      ...
      private static String ConvertWord(string word) {
        //TODO: Solution here 
        return word; // <- Stub
      }
      private static String ConvertPhrase(string phrase) {
        // Regex (not Split) to preserve punctuation: 
        // we convert each word (continued sequence of letter A..Z a..z or ')
        // within the original phrase 
        return Regex.Replace(phrase, @"[A-Za-z']+", match => ConvertWord(match.Value));
      }

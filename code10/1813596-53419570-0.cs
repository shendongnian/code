      private static String ConvertWord(string word) {
        //TODO: Solution here 
        return word; // <- Stub
      }
      private static String ConvertPhrase(string phrase) {
        // Regex (not Split) to preserve punctuation
        return Regex.Replace(phrase, @"[A-Za-z]+", match => ConvertWord(match.Value));
      }

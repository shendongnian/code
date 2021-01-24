      public partial class Form1: Form {
        ...
        List<string> words = new List<string>();
        List<string> guessedLetters = new List<string>();
        string word = "sword";
        ...
        private char[] letters {
          get {
            return null == word 
              ? new char[0]
              : word.ToCharArray(); 
          }
        } 

      public partial class Form1: Form {
        ...
        List<string> words = new List<string>();
        List<string> guessedLetters = new List<string>();
        string word;
        // Turning word into char array
        char[] letters;
        public Form1() {
          word = "sword"; 
          letters = word.ToCharArray();         
        }  
      }

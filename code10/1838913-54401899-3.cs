    class Hangman
    {
        static void Main()
        {
            Hangman item = new Hangman();
            item.Init();
            
            Console.WriteLine(item.Guessed); // ____
            
            item.GuessLetter('t'); // true
            Console.WriteLine(item.Guessed); // T__t
            
            item.GuessLetter('a'); // false
            Console.WriteLine(item.Guessed); // T__t
            
            item.GuessLetter('e'); // true
            Console.WriteLine(item.Guessed); // Te_t
        }
        
        string Word {get;set;}
        string Guessed {get;set;}
        
        void Init()
        {
            Word = "Test";
            Guessed = new string('_',Word.Length);
        }
        
        bool GuessLetter(char letter)
        {
            bool guessed = false;
            
            // use a stringbuilder so you can change any character
            var sb = new StringBuilder(Guessed);
            
            // for each character of Word, we check if it is the one we claimed
            for(int i=0; i<Word.Length; i++)
            {
                // Let's put both characters to lower case so we can compare them right
                if(Char.ToLower(Word[i]) == Char.ToLower(letter)) // have we found it?
                {
                    // Yeah! So we put it in the stringbuilder at the same place
                    sb[i] = Word[i];
                    guessed = true;
                }
            }
            
            // reassign the stringbuilder's representation to Guessed
            Guessed = sb.ToString();
            
            // tell if you guessed right
            return guessed;
        }
    }

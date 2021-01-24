    class Hangman
    {
        static void Main()
        {
            Hangman item = new Hangman();
            item.Init();
            
            Console.WriteLine(item.Guessed); // ____
            
            item.GuessLetter('t');
            Console.WriteLine(item.Guessed); // T__t
            
            item.GuessLetter('a');
            Console.WriteLine(item.Guessed); // T__t
            
            item.GuessLetter('e');
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
            
            var sb = new StringBuilder(Guessed);
            
            for(int i=0; i<Word.Length; i++)
            {
                if(Word.ToLower()[i] == letter) // have we found it?
                {
                    // Yeah!
                    sb[i] = Word[i];
                    guessed = true;
                }
            }
            
            Guessed = sb.ToString();
            
            return guessed;
        }
    }

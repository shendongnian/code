    static void Main(string[] args)
    {
    CheckWord();
    Console.ReadKey();
    }
        private static void CheckWord()
        {
            while (true)
            {
                string errorMessage = "Error: invalid input ... enter a valid entry";
                string word = Console.ReadLine(); 
                if (word != "word")
                {
                    Console.SetCursorPosition(word.Length +1 , 0);
                    Console.Write(errorMessage);
                    Console.ReadKey();
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i <= word.Length + errorMessage.Length +1 ; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, 0);
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
        }

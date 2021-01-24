    using System;
    
    namespace SimpleProblem
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Task:
                // The program asks the user to enter the text, after 
                // entering the text, the program declares how many words
                // are in the text. It also counts the amount of digits in 
                // the text and displays it on the screen.
    
                Console.WriteLine("Enter a Text");
                string word = Console.ReadLine();
                int wordCount = 0;
    
                char[] wordsArray = word.ToCharArray();
                foreach (var item in wordsArray)
                {
                    //Counting the number of words in array.
                    wordCount = wordCount + 1;
                }
    
                Console.WriteLine("Entered Text: " + word);
                Console.WriteLine("No. of Counts: " + wordCount);
    
            }
        }
    }

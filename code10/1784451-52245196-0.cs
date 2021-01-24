    string sentence = Console.ReadLine();
            while (true)
            {
                if (String.IsNullOrEmpty(sentence))
                {
                    Console.WriteLine("Please, do not leave the sentence field empty!");
                    Console.WriteLine("Enter your desired sentence again: ");
                }
                else if (sentence.Split(' ').Length < 5)
                {
                    Console.WriteLine("\r\nThe sentece entered isn't valid. Must have a least six words!");
                    Console.WriteLine("Enter a sentence with a least 6 words: ");
                }
                else break;
                sentence = Console.ReadLine();
            }

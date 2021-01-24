                Console.WriteLine("Which word is the longest?");
            int howMany = 5;//Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} words and I will tell you which is the longest", howMany);
            string LongestWord = "";
            int counter = 0;
            while (counter < howMany)
            {
                Console.WriteLine("Enter a word {0} > ", counter + 1);
                string temp = Console.ReadLine();
                if (temp.Length > LongestWord.Length) // check if the new word is longer than the current longest word
                {
                    LongestWord = temp;
                }
                counter++; //update counter
            }
            Console.WriteLine($"{LongestWord} is the longest word"); // after exiting the loop, print the longest word

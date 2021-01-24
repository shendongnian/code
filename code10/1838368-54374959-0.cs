                Console.WriteLine("Which word is the longest?");
            int howMany = 5;//Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter {0} words and I will tell you which is the longest", howMany);
            string userWord = Console.ReadLine();
            int counter = 0;
            while (counter < howMany)
            {
                Console.WriteLine("Enter a word {0} > ", counter + 1);
                string wordLength = (userWord.Length).ToString();
                counter++;
                Console.ReadLine();//Now the readline is inside the loop
            }

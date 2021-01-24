    //Random number generator
            Random rnd = new Random();
            int randInt = rnd.Next(0, 9);
            //Questions array Question/Answer
            string[,] array2D = new string[10, 2] {
            { "Mario Kart is a video game series publish by which company?", "Nintendo" },
            { "What was the first console video game that allowed the game to be saved?", "The Legend of Zelda" },
            { "The Connecticut Leather Company later became what toy company that was popular in the 1980s for its Cabbage Patch Kids and video game consoles?", "Coleco" },
            { "Nintendo is a consumer electronics and video game company founded in what country?", "Japan" },
            { "The first person shooter video game Doom was first released in what year?", "1993" },
            { "In what year did Nintendo release its first game console in North America?", "1985" },
            { "In the world of video games, what does NES stand for?", "Nintendo Entertainment System" },
            { "In what year was the Nintendo 64 officially released?", "1996" },
            { "What was the most popular video game in the year 1999?", "Doom" },
            { "If you have any kind of console known to mankind, what will your mother call it no matter what?", "A Nintendo" } };
            //printing the question
            System.Console.WriteLine(array2D[randInt, 0]);
            //System.Console.ReadKey(); Removed
            //taking user input
            string Answer = Console.ReadLine();
            //checking to see if the answer is correct
            if (Answer.Equals(array2D[randInt, 1]))
            {
                //the console exclamation for the right answer given in any scenario.
                Console.WriteLine("Correct Answer! Good job!");
                Console.ReadKey();
            }
            else
            {
                //the console exlamation for the incorrect answer in any given scnario
                Console.WriteLine("Aw man! You got it wrong! Better luck next time :(");
                Console.WriteLine("The correct answer was {0}", array2D[randInt, 1]);
                Console.ReadKey();
            }

        public int GetChoice(int MinRange, int MaxRange)
        {
            do
            {
                string menuChoice = Console.ReadLine();
                int menuNumber = -1;
                if (int.TryParse(menuChoice, out menuNumber))
                {
                    if (menuNumber >= MinRange && menuNumber <= MaxRange)
                        return menuNumber;
                }
                AlertMessage($"You have enetered an invalid Number, please select a correct option! ({MinRange}-{MaxRange})", ConsoleColor.Red);
            } while (true);
        }

         static string HeadsOrTails()
        {
            string guessHistory = String.Empty;
            // Guess heads or tails 5 times
            Random random = new Random();
            for (int currentGuess = 0; currentGuess < 5; currentGuess++)
            {
                if (random.Next(2) == 0)
                    guessHistory += 'H';
                else
                    guessHistory += 'T';
            }
            // Analyse pattern of guesses
            if (guessHistory.Substring(0, 4) == "HHTT" || guessHistory.Substring(1, 4) == "HHTT")
            {
                // If guess history contains HHTT then make the 6th guess = H
                guessHistory += 'H';
            }
            return guessHistory;
        }

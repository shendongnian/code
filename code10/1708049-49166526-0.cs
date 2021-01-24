            int max = NumVotes.Max();
            string winnerName = null;
                for (var i = 0; i < numVotes.Length; i++)
                {
                    if (NumVotes[i] = max) 
                    {
                        winnerName = CandidateNames[i];
                    }
                }
            Console.WriteLine(winnerName);
        }

        for (int scoreIndex = 0; scoreIndex < studentSum; scoreIndex++)
        {
          for(int j=0; j<studentSum; j++) 
          {
            Console.WriteLine("Enter score");
            var score = Console.ReadLine();
            Console.WriteLine(string.Empty);
            int parsedScore = 0;
            success = int.TryParse(score, out parsedScore);
            studentScores[scoreIndex,j] = parsedScore;
          }
        }

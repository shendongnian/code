     // This method rates the position in a [-1600..1500] range 
     // [1st player has lost..1st player has won]
     int findTwoPions(Boolean?[,] jeu) {
       // Edge cases: win or lose
       if (WinningLines(jeu).Any(line => line.All(cell => cell == true)))
         return 1500;  // 1st has won 
       else if (WinningLines(jeu).Any(line => line.All(cell => cell == false))) 
         return -1600; // 1st has lost 
       //TODO: add more heuristics (depending who is on move)
       
       // Example: if 1st is on move and can win by its next move? Say we have aposition like
       //   X..
       //   0X.
       //   .0.
       if (FirstIsOnMove(jeu)) { 
         if (WinningLines(jeu)
           .Any(line => line.Sum(item => item == true ? 1 : item == false ? -1 : 0) == 2))
             return 1200; // 1st is going to win (unless it makes a blind)
       }
       else {
         if (WinningLines(jeu)
           .Any(line => line.Sum(item => item == true ? 1 : item == false ? -1 : 0) == -2))
             return -1200; // 2st is going to win (unless it makes a blind) 
       }
       // Neutral position - neither 1st not 2nd have any advantages 
       return 0;
     }

        ...
        // remove all the code starting from "//In line" up to "return somme;"
        if (WinningLines(jeu).Any(line => line.All(cell => cell == true)))
          return 1500;  // 1st has won
        else if (WinningLines(jeu).Any(line => line.All(cell => cell == false))) 
          return -1600; // 2nd has won
        return somme;   // neither 1st nor 2nd has won
      }

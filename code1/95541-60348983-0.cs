    int[] scores = { 100, 90, 90, 80, 75, 60 };
    int[] alice = { 50, 65, 77, 90, 102 };
    int[] scoreBoard = new int[scores.Length + alice.Length];
    
                int j = 0;
    
                for (int i=0;i<(scores.Length+alice.Length);i++)  // to combine two arrays
                {
                    if(i<scores.Length)
                    {
                        scoreBoard[i] = scores[i];
                    }
                    else
                    {
                        scoreBoard[i] = alice[j];
                        j = j + 1;
                        
                    }
                }
    
    
                for (int l = 0; l < (scores.Length + alice.Length); l++)
                {
                    Console.WriteLine(scoreBoard[l]);
                }

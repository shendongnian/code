    public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            // Step 1
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    double GetSimilarityRatio(String FullString1, String FullString2, out double WordsRatio, out double RealWordsRatio)
        {
            double theResult = 0;
            String[] Splitted1 = FullString1.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            String[] Splitted2 = FullString2.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            if (Splitted1.Length < Splitted2.Length)
            {
                String[] Temp = Splitted2;
                Splitted2 = Splitted1;
                Splitted1 = Temp;
            }
            int[,] theScores = new int[Splitted1.Length, Splitted2.Length];//Keep the best scores for each word.0 is the best, 1000 is the starting.
            int[] BestWord = new int[Splitted1.Length];//Index to the best word of Splitted2 for the Splitted1.
            
            for (int loop = 0; loop < Splitted1.Length; loop++) 
            {
                for (int loop1 = 0; loop1 < Splitted2.Length; loop1++) theScores[loop, loop1] = 1000;
                BestWord[loop] = -1;
            }
            int WordsMatched = 0;
            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                String String1 = Splitted1[loop];
                for (int loop1 = 0; loop1 < Splitted2.Length; loop1++)
                {
                    String String2 = Splitted2[loop1];
                    int LevenshteinDistance = Compute(String1, String2);
                    theScores[loop, loop1] = LevenshteinDistance;
                    if (BestWord[loop] == -1 || theScores[loop, BestWord[loop]] > LevenshteinDistance) BestWord[loop] = loop1;
                }
            }
            
            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                if (theScores[loop, BestWord[loop]] == 1000) continue;
                for (int loop1 = loop + 1; loop1 < Splitted1.Length; loop1++)
                {
                    if (theScores[loop1, BestWord[loop1]] == 1000) continue;//the worst score available, so there are no more words left
                    if (BestWord[loop] == BestWord[loop1])//2 words have the same best word
                    {
                        //The first in order has the advantage of keeping the word in equality
                        if (theScores[loop, BestWord[loop]] <= theScores[loop1, BestWord[loop1]])
                        {
                            theScores[loop1, BestWord[loop1]] = 1000;
                            int CurrentBest = -1;
                            int CurrentScore = 1000;
                            for (int loop2 = 0; loop2 < Splitted2.Length; loop2++)
                            {
                                //Find next bestword
                                if (CurrentBest == -1 || CurrentScore > theScores[loop1, loop2])
                                {
                                    CurrentBest = loop2;
                                    CurrentScore = theScores[loop1, loop2];
                                }
                            }
                            BestWord[loop1] = CurrentBest;
                        }
                        else//the latter has a better score
                        {
                            theScores[loop, BestWord[loop]] = 1000;
                            int CurrentBest = -1;
                            int CurrentScore = 1000;
                            for (int loop2 = 0; loop2 < Splitted2.Length; loop2++)
                            {
                                //Find next bestword
                                if (CurrentBest == -1 || CurrentScore > theScores[loop, loop2])
                                {
                                    CurrentBest = loop2;
                                    CurrentScore = theScores[loop, loop2];
                                }
                            }
                            BestWord[loop] = CurrentBest;
                        }
                        loop = -1;
                        break;//recalculate all
                    }
                }
            }
            for (int loop = 0; loop < Splitted1.Length; loop++)
            {
                if (theScores[loop, BestWord[loop]] == 1000) theResult += Splitted1[loop].Length;//All words without a score for best word are max failures
                else
                {
                    theResult += theScores[loop, BestWord[loop]];
                    if (theScores[loop, BestWord[loop]] == 0) WordsMatched++;
                }
            }
            int theLength = (FullString1.Replace(" ", "").Length > FullString2.Replace(" ", "").Length) ? FullString1.Replace(" ", "").Length : FullString2.Replace(" ", "").Length;
            if(theResult > theLength) theResult = theLength;
            theResult = (1 - (theResult / theLength)) * 100;
            WordsRatio = ((double)WordsMatched / (double)Splitted2.Length) * 100;
            RealWordsRatio = ((double)WordsMatched / (double)Splitted1.Length) * 100;
            return theResult;
        }

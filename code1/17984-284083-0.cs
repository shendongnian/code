    private static string FindRelevantSnippets(string infoText, string[] searchTerms)
        {
            List<int> termLocations = new List<int>();
            foreach (string term in searchTerms)
            {
                int termStart = infoText.IndexOf(term);
                while (termStart > 0)
                {
                    termLocations.Add(termStart);
                    termStart = infoText.IndexOf(term, termStart + 1);
                }
            }
            if (termLocations.Count == 0)
            {
                if (infoText.Length > 250)
                    return infoText.Substring(0, 250);
                else
                    return infoText;
            }
            termLocations.Sort();
            List<int> termDistances = new List<int>();
            for (int i = 0; i < termLocations.Count; i++)
            {
                if (i == 0)
                {
                    termDistances.Add(0);
                    continue;
                }
                termDistances.Add(termLocations[i] - termLocations[i - 1]);
            }
            int smallestSum = int.MaxValue;
            int smallestSumIndex = 0;
            for (int i = 0; i < termDistances.Count; i++)
            {
                int sum = termDistances.Skip(i).Take(5).Sum();
                if (sum < smallestSum)
                {
                    smallestSum = sum;
                    smallestSumIndex = i;
                }
            }
            int start = Math.Max(termLocations[smallestSumIndex] - 128, 0);
            int len = Math.Min(smallestSum, infoText.Length - start);
            len = Math.Min(len, 250);
            return infoText.Substring(start, len);
        }

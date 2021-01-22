     private static string Concatenated(string longsentence)
        {
            const int batchSize = 15;
            string concatanated = "";
            int chanks = longsentence.Length / batchSize;
            int currentIndex = 0;
            while (chanks > 0)
            {
                var sub = longsentence.Substring(currentIndex, batchSize);
                concatanated += sub + "/n";
                chanks -= 1;
                currentIndex += batchSize;
            }
            if (currentIndex < longsentence.Length)
            {
                int start = currentIndex;
                var finalsub = longsentence.Substring(start);
                concatanated += finalsub;
            }
            return concatanated;
        }

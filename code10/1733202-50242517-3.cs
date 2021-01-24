    public String[,] MatchPlayers(String[,] leaguePairs, String[,] playerPairs)
        {
            var results = new List<(string, string)>();
            for (var i = 0; i < leaguePairs.GetLength(0); i++)
            {
                for (var j = 0; j < playerPairs.GetLength(0); j++)
                {
                    if (Equals(playerPairs[j, 1], leaguePairs[i, 1]) || Equals(playerPairs[j, 1], "*"))
                    {
                        results.Add((playerPairs[j, 0], leaguePairs[i, 0]);
                    }
                }
            }
            var stringArray = new String[results.Count, 2];
            for (var i = 0; i < results.Count; i++)
            {
                var result = results[i];
                stringArray[i, 0] = result.Item1;
                stringArray[i, 1] = result.Item2;
            }
            return stringArray;
        }

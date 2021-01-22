     private IEnumerable<GridSquare> GetGridSquares(string line)
        {
            var splittedLine = line.Split(' ');
            foreach (var gsStr in splittedLine)
            {
                if (gsStr.Length != 4)
                {
                    continue;
                }
                
                yield return new GridSquare(gsStr[0], gsStr[1], gsStr[2], gsStr[3]);
            }
        }

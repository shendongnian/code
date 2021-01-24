        Position LookForNumber(int[,] matrix, int findNumber)
        {
            Position position = new Position();
            for (int r = matrix.GetLength(0) - 1; r >= 0 ; r--)
            {
                for (int c = matrix.GetLength(1) - 1; c >= 0 ; c--)
                {
                    if (matrix[r, c] == findNumber)
                    {
                        Console.WriteLine("Your number {0} first appears on position 
                  {1},{2}", findNumber, r, c);
                        position.row = r;
                        position.column = c;
                        return position;
                    }
                }
            }
            return null;
        }

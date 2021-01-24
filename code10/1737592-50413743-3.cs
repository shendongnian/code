           public static List<space> GetList()
            {
                List<space> tiles = new List<space>();
                string[] spaceLetter = {"A", "B", "C", "D", "E", "F", "G", "H"};
                const int X_BORDER = 2;
                const int X_WIDTH = 3;
                const int Y_BORDER = 2;
                const int Y_HEIGHT = 3;
                for(int col = 0; col < 8; col++)
                {
                    for(int row = 0; row < 8; row++)
                    {
                        space newspace = new space();
                        tiles.Add(newspace);
                        newspace.isWhite = (row + col) % 2 == 0 ? true : false;
                        newspace.spaceValue = spaceLetter[row] + (col + 1).ToString();
                        newspace.minXPosition = (X_WIDTH * col) + X_BORDER;
                        newspace.maxXPosition = (X_WIDTH * col) + X_WIDTH + X_BORDER - 1;
                        newspace.minYPosition = (Y_HEIGHT * row) + Y_BORDER;
                        newspace.maxYPosition = (Y_HEIGHT * row) + Y_HEIGHT + Y_BORDER - 1;
                    }
                }

    public Board AssignTilesToCoords(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tile tile = new Tile(i, j, false);
                    board.tiles[i, j] = tile;
                }
            }
            return board;
        }

        // Fills the map with the tile passed in
        public static void FillMap(MapTile tile)
        {
            // For all rows
            for (int row = 0; row < 32; row++)
            {
                // For all columns
                for (int col = 0; col < 128; col++)
                {
                    // Make that position the same as the tile passed in
                    map[row, col] = tile;
                }
            }
        }

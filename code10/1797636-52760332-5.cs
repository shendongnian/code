        // Create rectangle on the map with the maptile
        public static void CreateRectangle(Point startPoint, int width, int height, MapTile tile)
        {
            // Starting from the point we specified, create a rectangle of the given map tile
            for (int row = startPoint.X; row < startPoint.X + width; row++)
            {
                // For all columns
                for (int col = startPoint.Y; col < startPoint.Y + height; col++)
                {
                    // Make that position the same as the tile passed in
                    map[row, col] = tile;
                }
            }
        }

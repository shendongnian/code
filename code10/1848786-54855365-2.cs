    public static List<Point> GetNeighborMatches(string[,] grid, Point item, string valueToFind)
    {
        var result = new List<Point>();
        // if our grid is empty or the item isn't in it, return an empty list
        if (grid == null || grid.Length == 0 ||
            item.X < 0 || item.X > grid.GetUpperBound(0) ||
            item.Y < 0 || item.Y > grid.GetUpperBound(1))
        {
            return result;
        }
        // Get min and max values of x and y for searching
        var minX = Math.Max(item.X - 1, 0);
        var maxX = Math.Min(item.X + 1, grid.GetUpperBound(0));
        var minY = Math.Max(item.Y - 1, 0);
        var maxY = Math.Min(item.Y + 1, grid.GetUpperBound(1));
        // Loop through all neighbors to find a match
        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                // Continue looping if we're on the 'item'
                if (x == item.X && y == item.Y) continue;
                // If this is a match, add it to our list
                if (grid[x, y] == valueToFind) result.Add(new Point(x, y));
            }
        }
        // Return all the matching neighbors
        return result;
    }

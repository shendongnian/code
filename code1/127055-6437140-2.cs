    public WordSearcher(char[,] puzzle)
    {
        Puzzle = puzzle;
    }
    public char[,] Puzzle { get; set; }
    // represents the array offsets for each
    // character surrounding the current one
    private Coordinate[] directions = 
    {
        new Coordinate(-1, 0), // West
        new Coordinate(-1,-1), // North West
        new Coordinate(0, -1), // North
        new Coordinate(1, -1), // North East
        new Coordinate(1, 0),  // East
        new Coordinate(1, 1),  // South East
        new Coordinate(0, 1),  // South
        new Coordinate(-1, 1)  // South West
    };
    public Range Search(string word)
    {
        // scan the puzzle line by line
        for (int y = 0; y < Puzzle.GetLength(0); y++)
        {
            for (int x = 0; x < Puzzle.GetLength(1); x++)
            {
                if (Puzzle[y, x] == word[0])
                {
                    // and when we find a character that matches 
                    // the start of the word, scan in each direction 
                    // around it looking for the rest of the word
                    var start = new Coordinate(x, y);
                    var end = SearchEachDirection(word, x, y);
                    if (end != null)
                    {
                        return new Range(start, end);
                    }
                }
            }
        }
        return null;
    }
    private Coordinate SearchEachDirection(string word, int x, int y)
    {
        char[] chars = word.ToCharArray();
        for (int direction = 0; direction < 8; direction++)
        {
            var reference = SearchDirection(chars, x, y, direction);
            if (reference != null)
            {
                return reference;
            }
        }
        return null;
    }
    private Coordinate SearchDirection(char[] chars, int x, int y, int direction)
    {
        // have we ve moved passed the boundary of the puzzle
        if (x < 0 || y < 0 || x >= Puzzle.GetLength(1) || y >= Puzzle.GetLength(0))
            return null;
        if (Puzzle[y, x] != chars[0])
            return null;
        // when we reach the last character in the word
        // the values of x,y represent location in the
        // puzzle where the word stops
        if (chars.Length == 1)
            return new Coordinate(x, y);
        // test the next character in the current direction
        char[] copy = new char[chars.Length - 1];
        Array.Copy(chars, 1, copy, 0, chars.Length - 1);
        return SearchDirection(copy, x + directions[direction].X, y + directions[direction].Y, direction);
    }
}

    SortedList<int, int> levels = new SortedList<int, int>
        {
            {0, 1},
            {100, 2},
            {200, 3},
            {400, 4},
            {600, 5},
        };
    public int Experience;
    public int Level
    {
        get
        {
            return levels.Last(kvp => Experience >= kvp.Key).Value;
        }
    }

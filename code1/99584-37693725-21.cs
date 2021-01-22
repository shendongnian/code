    private static readonly int[,] _addOffset = 
    {
      // 0  1  2  3  4
        {0, 1, 2, 3, 4}, // Su  0
        {0, 1, 2, 3, 4}, // M   1
        {0, 1, 2, 3, 6}, // Tu  2
        {0, 1, 4, 5, 6}, // W   3
        {0, 1, 4, 5, 6}, // Th  4
        {0, 3, 4, 5, 6}, // F   5
        {0, 2, 3, 4, 5}, // Sa  6
    };
    public static DateTime AddWeekdays(this DateTime date, int weekdays)
    {
        int extraDays = weekdays % 5;
        int addDays = weekdays >= 0
            ? (weekdays / 5) * 7 + _addOffset[(int)date.DayOfWeek, extraDays]
            : (weekdays / 5) * 7 - _addOffset[6 - (int)date.DayOfWeek, -extraDays];
        return date.AddDays(addDays);
    }

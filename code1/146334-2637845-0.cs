    static DayOfWeek[] _toDaysTable = new DayOfWeek[] {
        DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
        DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday
    };
    static DayOfWeek ToDayOfWeek(int myDayOfWeek)
    {
         int index = myDayOfWeek - 1;
         if (index < 0 || index >= _toDaysTable.Length)
              throw new ArgumentOutOfRangeException("myDayOfWeek");
         return _toDaysTable[index];
    }
    static int FromDayOfWeek(DayOfWeek day)
    {
        int index = Array.IndexOf(_toDaysTable, day);
        if (index < 0)
            throw new ArgumentOutOfRangeException("day");
        return index + 1;
    }

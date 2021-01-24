    void Main() {
        var workPattern = new List<DayState> { DayState.MorningShift, DayState.AfternoonShift, DayState.NightShift, DayState.OffDay, DayState.OffDay };
        var startDate = new DateTime(2018, 1, 1);
    
        var queryDate = new DateTime(2018, 1, 4);
        Console.WriteLine($"{queryDate:d} is {StateOfDate(startDate, workPattern, queryDate)}");
        
        queryDate = new DateTime(2018, 1, 21);
        Console.WriteLine($"{queryDate:d} is {StateOfDate(startDate, workPattern, queryDate)}");
    
        queryDate = new DateTime(2018, 2, 6);
        Console.WriteLine($"{queryDate:d} is {StateOfDate(startDate, workPattern, queryDate)}");
    
        queryDate = new DateTime(2018, 3, 4);
        Console.WriteLine($"{queryDate:d} is {StateOfDate(startDate, workPattern, queryDate)}");
    }
    
    // Define other methods and classes here
    public enum DayState {
        MorningShift, AfternoonShift, NightShift, OffDay
    };
    
    public DayState StateOfDate(DateTime startDate, List<DayState> workPattern, DateTime queryDate) {
        var numDays = Math.Floor((queryDate-startDate).TotalDays);
        var patternOffset = ((int)numDays) % workPattern.Count;
        return workPattern[patternOffset];
    }

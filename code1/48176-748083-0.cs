    public int GetDay(DateTime date, out string name)
    {
      // ...
    }
    public DayOfWeek GetDay(DateTime date)
    {
      // ...
    }
    public class DayOfWeek
    {
      public int Day { get; set; }
      public string Name { get; set; }
    }

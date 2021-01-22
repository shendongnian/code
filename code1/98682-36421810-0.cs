    using System.Linq;
    public List<DayOfWeek> DaysOfWeek
    {
      get
      {
        return Enum.GetValues(typeof(DayOfWeek))
                   .OfType<DayOfWeek>()
                   .ToList();
      }
    }

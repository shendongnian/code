    public class Shift {
        public int ID { get; set; }
        public DateTime Start {get;set;}
        public DateTime End { get; set;}
        public DayOfWeek Day { get; set;}
    }
    var query = shifts.Where( s1 => shifts.Any( s2 => s1.ID != s2.ID
                                            && s1.Day == s2.Day
                                            && (s2.Start <= s1.Start && s1.Start <= s2.End)
                                                 || (s1.Start <= s2.Start && s2.Start <= s1.End))
                      .GroupBy( s => s.Day );
    foreach (var group in query.OrderBy( g => g.Key ))
    {
        Console.WriteLine( group.Key ); // Day of Week
        foreach (var shift in group)
        {
             Console.WriteLine( "\t" + shift.ID );
        }
    }

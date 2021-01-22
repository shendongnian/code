    public class TimetableWithMaxMin
    {
        public Timetable Timetable { get; set; }
        public DateTime Max { get; set; }
        public DateTime Min { get; set; }
    }
    public IQueryable<TimetableWithMaxMin> GetTimetables()
    {
        return from t in _entities.Timetables
               select new TimetableWithMaxMin
               {
                   Timetable = t,
                   Max = _entities.Timetables.Max(t => t.StartTime),
                   Min = _entities.Timetables.Min(t => t.StartTime)
               };
    }

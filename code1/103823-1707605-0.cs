     public IQueryable<Timetable> GetTimetables()
        {
            return from t in _entities.Timetables
                   select new {maxt = Max(t.StartTime), mint = Min(t.StartTime)};
        }

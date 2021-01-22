    public int CalendarWeeks(DateTime from, DateTime to) {
        
        // number of multiples of 7 
        // (rounded up, since 15 days would span at least 3 weeks)
        // and if we end on a day before we start, we know it's another week
        return Math.Ceiling(to.Subtract(from).Days / 7.0) + 
                (to.DayOfWeek <= from.DayOfWeek) ? 1 : 0;
    }

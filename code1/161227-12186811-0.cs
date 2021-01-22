    private static int inclusiveDays(DateTime s1, DateTime e1, DateTime s2, DateTime e2)
    {
        // If they don't intersect return 0.
        if (!(s1 <= e2 && e1 >= s2))
        {
            return 0;
        }
        // Take the highest start date and the lowest end date.
        DateTime start = s1 > s2 ? s1 : s2;
        DateTime end = e1 > e2 ? e2 : e1;
        // Add one to the time range since its inclusive.
        return (int)(end - start).TotalDays + 1;
    }

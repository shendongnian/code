    public static class Extensions
    {
        public static bool ContainsDate(this IEnumerable<Period> periods, DateTime timeToCheck)
        {
            return periods?.Any(p => timeToCheck >= p.Start && timeToCheck <= p.End) ?? false;
        }
    }

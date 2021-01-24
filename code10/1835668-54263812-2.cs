    static public string ConstructDays(Days days)
    {
        return string.Join(",", Enum.GetValues(typeof(Days))
                                    .Cast<Days>()
                                    .Where(d => days.HasFlag(d) && d != Days.None)
                                    .Select(d => Math.Log((int)d, 2)));  // 1,3,6
    }

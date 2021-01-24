    public static int GetCount(this object q, string match)
    {
        var values = ((Type)q.GetType()).GetProperties()
            .Select(m => (object)m.GetValue(q))
            .Count(m => match.Equals(m));
        return values;
    }

    public static IEnumerable<string> FindBlankFields(Staff staff)
    {
        return staff.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.CanRead)
            .Select(p => new { Property = p, Value = p.GetValue(staff, null) })
            .Where(a => a.Value == null || String.IsNullOrEmpty(a.Value.ToString()))
            .Select(a => a.Property.Name);
    }

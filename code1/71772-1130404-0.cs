    private static MS[] ConvertStringToEnumArray(string text)
    {
        string[] values = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        return Array.ConvertAll(values, value => (MS)Enum.Parse(typeof(MS), value));
    }

    static void TestFormat(string formatter, params string[] values)
    {
        try
        {
            string.Format(formatter, values);
        }
        catch (FormatException e)
        {
            throw new Exception("the format is bad!!", e);
        }
    }

    private static void TestStringBuilder()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"""saoetuhasoethuasteuhasoetnuh""");
        foreach (char c in builder.ToString())
        {
            System.Diagnostics.Debug.Assert(c != '\\', "EPIC STRINGBUILDER FAIL");
        }
    }

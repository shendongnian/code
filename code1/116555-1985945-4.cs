    static void Main(string[] args)
    {
        try
        {
            string[] parameters = { "ABC", "DEF", "GHI" };
            string camlQuery = CreateCAMLQuery(parameters);
            Console.WriteLine(camlQuery);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }
    private static string CreateCAMLQuery(string[] parameters)
    {
        StringBuilder sb = new StringBuilder();
        if (parameters.Length == 0)
        {
            // perhaps set a default query?
            AppendEQ(sb, "all");
        }
        // "AND" each parameter to the query
        for (int i = 0; i < parameters.Length; i++)
        {
            AppendEQ(sb, parameters[i]);
            if (i > 0)
            {
                sb.Insert(0, "<And>");
                sb.Append("</And>");
            }
        }
        sb.Insert(0, "<Where>");
        sb.Append("</Where>");
        return sb.ToString();
    }
    private static void AppendEQ(StringBuilder sb, string value)
    {
        // put your field's internal name in place of Category
        sb.Append("<Eq>");
        sb.Append("<FieldRef Name='Category'/>");
        sb.AppendFormat("<Value Type='Choice'>{0}</Value>", value);
        sb.Append("</Eq>");
    }

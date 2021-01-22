    public static string DropdownEnum(this System.Web.Mvc.HtmlHelper helper,
                                      Enum values)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<select name=\"blah\">");
        string[] names = Enum.GetNames(values.GetType());
        foreach(string name in names)
        {
            sb.Append("<option value=\"");
            sb.Append(((int)Enum.Parse(values.GetType(), name)).ToString());
            sb.Append("\">");
            sb.Append(name);
            sb.Append("</option>");
        }
        sb.Append("</select>");
        return sb.ToString();
    }

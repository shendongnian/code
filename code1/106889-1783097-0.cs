    protected static string GetItems(IDataItemContainer container)
    {
        StringBuilder result = new StringBuilder();
        string[] StaticSQLFields = MyStaticClass.StaticSQLFields;
        for (int i = 0; i < StaticSQLFields.Length; i++)
        {
            sb.Append(DataBinder.Eval(container.DataItem, StaticSQLFields[i]) + "<br>");
        }
        return sb.ToString();
    }

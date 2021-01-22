    private string LoadSQLStatement(string statementName)
    {
        string sqlStatement = string.Empty;
        string namespacePart = "ConsoleApplication1";
        string resourceName = namespacePart + "." + statementName;
        using(Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            if (stm != null)
            {
                sqlStatement = new StreamReader(stm).ReadToEnd();
            }
        }
        return sqlStatement;
    }

    public void LogSQL(string rowsSQL, float timeSQL, string stringSQL)
    {
        string logFile = Path.Combine(pathTxt(), $"LogsSQL-{DateTime.Today.ToString("yyyyMMdd"}).txt")
        using(System.IO.StreamWriter sw = System.IO.File.AppendText(logFile))
        {
            string x = System.String.Format(.......);
            sw.WriteLine(x);
        }
    }

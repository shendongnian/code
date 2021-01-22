    public static class ExtensionMethodsSqlCommand
    {
        #region Public
        private static bool IsGo(string psCommandLine)
        {
            if (psCommandLine == null)
                return false;
            psCommandLine = psCommandLine.Trim();
            if (string.Compare(psCommandLine, "GO", StringComparison.OrdinalIgnoreCase) == 0)
                return true;
            if (psCommandLine.StartsWith("GO", StringComparison.OrdinalIgnoreCase))
            {
                psCommandLine = (psCommandLine + "--").Substring(2).Trim();
                if (psCommandLine.StartsWith("--"))
                    return true;
            }
            return false;
        }
        [System.Diagnostics.DebuggerHidden]
        public static void ExecuteNonQueryWithGos(this SqlCommand poSqlCommand)
        {
            string sCommandLong = poSqlCommand.CommandText;
            using (StringReader oStringReader = new StringReader(sCommandLong))
            {
                string sCommandLine;
                string sCommandShort = string.Empty;
                while ((sCommandLine = oStringReader.ReadLine()) != null)
                    if (ExtensionMethodsSqlCommand.IsGo(sCommandLine))
                    {
                        if (sCommandShort.IsNullOrWhiteSpace() == false)
                        {
                            if ((poSqlCommand.Connection.State & ConnectionState.Open) == 0)
                                poSqlCommand.Connection.Open();
                            using (SqlCommand oSqlCommand = new SqlCommand(sCommandShort, poSqlCommand.Connection))
                                oSqlCommand.ExecuteNonQuery();
                        }
                        sCommandShort = string.Empty;
                    }
                    else
                        sCommandShort += sCommandLine + "\r\n";
            }
        }
        #endregion Public
    }

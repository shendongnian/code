    private static string CreateNewConnectionString(string connectionName, string password)
    {
        var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").ConnectionStrings.ConnectionStrings[connectionName];
        var split = config.ConnectionString.Split(Convert.ToChar(";"));
        var sb = new System.Text.StringBuilder();
        for (var i = 0; i <= (split.Length - 1); i++)
        {
            if (split[i].ToLower().Contains("user id"))
            {
                split[i] += ";Password=" + password;
            }
            if (i < (split.Length - 1))
            {
                sb.AppendFormat("{0};", split[i]);
            }
            else
            {
                sb.Append(split[i]);
            }
        }
        return sb.ToString();
    }

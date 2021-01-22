    /// <summary>
    /// Displays a Connection String Builder (DataLinks) dialog.
    /// 
    /// Credits:
    /// http://www.codeproject.com/cs/database/DataLinks.asp
    /// http://www.codeproject.com/cs/database/DataLinks.asp?df=100&forumid=33457&select=1560237#xx1560237xx
    /// 
    /// Required COM references:
    /// %PROGRAMFILES%\Microsoft.NET\Primary Interop Assemblies\adodb.dll
    /// %PROGRAMFILES%\Common Files\System\Ole DB\OLEDB32.DLL
    /// </summary>
    /// <param name="currentConnectionString">Previous database connection string</param>
    /// <returns>Selected connection string</returns>
    private string PromptForConnectionString(string currentConnectionString)
    {
        MSDASC.DataLinks dataLinks = new MSDASC.DataLinksClass();
        ADODB.Connection dialogConnection;
        string generatedConnectionString = string.Empty;
    
        if (currentConnectionString == String.Empty)
        {
            dialogConnection = (ADODB.Connection)dataLinks.PromptNew();
            generatedConnectionString = dialogConnection.ConnectionString.ToString();
        }
        else
        {
            dialogConnection = new ADODB.Connection();
            dialogConnection.Provider = "SQLOLEDB.1";
            ADODB.Property persistProperty = dialogConnection.Properties["Persist Security Info"];
            persistProperty.Value = true;
    
            dialogConnection.ConnectionString = currentConnectionString;
            dataLinks = new MSDASC.DataLinks();
    
            object objConn = dialogConnection;
            if (dataLinks.PromptEdit(ref objConn))
            {
                generatedConnectionString = dialogConnection.ConnectionString.ToString();
            }
        }
        generatedConnectionString = generatedConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
        if (
                !generatedConnectionString.Contains("Integrated Security=SSPI")
                && !generatedConnectionString.Contains("Trusted_Connection=True")
                && !generatedConnectionString.Contains("Password=")
                && !generatedConnectionString.Contains("Pwd=")
            )
            if(dialogConnection.Properties["Password"] != null)
                generatedConnectionString += ";Password=" + dialogConnection.Properties["Password"].Value.ToString();
    
        return generatedConnectionString;
    }

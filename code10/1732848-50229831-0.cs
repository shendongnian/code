    SQLiteConnection conn = new SQLiteConnection("Data Source=:memory:");
    conn.Authorize += Conn_Authorize;
    ...
    private static void Conn_Authorize(object sender, AuthorizerEventArgs e)
    {
        if (e.ActionCode == SQLiteAuthorizerActionCode.Attach)
        {
            e.ReturnCode = SQLiteAuthorizerReturnCode.Deny;
        }
        else
        {
            e.ReturnCode = SQLiteAuthorizerReturnCode.Ok;
        }
    }

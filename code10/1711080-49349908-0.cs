    public bool SQLScript_ExecuteSQLScript(string ScriptLocation)
            {
                try
                {
                    //5 min timeout
                    SqlConnection SQLConn = new SqlConnection(cn + "; Connection Timeout = 300;");
                    string script = File.ReadAllText(ScriptLocation);
                    Server server = new Server(new ServerConnection(SQLConn));
    
                    server.ConnectionContext.ExecuteNonQuery(script);
    
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

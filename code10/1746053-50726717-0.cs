Alright so I found out why it was not updating it. Seems, for whatever reason, it needed **sp.Refresh();** First before I overwrote the textBody.
    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString);
    ServerConnection srvCon = new ServerConnection(sqlCon);
    sqlCon.Open();
    Server srv = new Server(srvCon);
    Database db = srv.Databases[sqlCon.Database];
    StoredProcedure sp = new StoredProcedure(db, "spRDLDataFetcher");
    sp.TextMode = false;
    sp.AnsiNullsStatus = false;
    sp.QuotedIdentifierStatus = true;
    sp.ImplementationType = ImplementationType.TransactSql;
    sp.Schema = "dbo";
    sp.Refresh(); //What was needed to make work
    string orgSPText = sp.TextBody;
    sp.TextBody = "SELECT blah FROM MyTable WHERE ID=1";
    sp.Recompile = true;
    sp.Alter();
    

    log = new log();
    log.SomeProperty = something; // This can be outside the "using"
    using (OracleConnection connection = new OracleConnection("..."))
    {
        log.Connection = conn;
        log.InsertData();
        ...
    }

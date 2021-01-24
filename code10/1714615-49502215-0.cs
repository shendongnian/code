    public void BuildConnectionString()
    {
        // Build connection string
        builder.DataSource = "|DataDirectory|TestDB.sqlite";   //
        builder.Pooling = true;
    }

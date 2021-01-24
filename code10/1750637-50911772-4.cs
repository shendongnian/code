    void Main()
    {
        var dbNames=this.GetAdditionalDatabaseNames(); dbNames.Add(this.Connection.Database);
		dbNames.Dump();
    }

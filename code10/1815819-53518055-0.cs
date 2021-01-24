    this.Connection = new OracleConnection();
    this.Connection.ConnectionString = ...
    this.Connection.Open();
    OracleGlobalization info = this.Connection.GetSessionInfo();
    info.TimeZone = "America/New_York";
    this.Connection.SetSessionInfo(info);

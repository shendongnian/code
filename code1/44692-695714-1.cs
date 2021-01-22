    public string ConnectionString
    {
        get { return this._connection.ConnectionString; }
        set
        {
            if (this._connection == null)
            {
                this._connection = new System.Data.SqlClient.SqlConnection();
            }
            this._connection.ConnectionString = value;
        }
    }

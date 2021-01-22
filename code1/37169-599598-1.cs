    public class Database : AbstractDatabase<SqlConnection, SqlCommand, SqlDataAdapter>
    {
				
					private string _ConnectionString;
					public string ConnectionString
					{
						get { return _ConnectionString; }
						set { _ConnectionString = value; }
					} //eof property FieldName 
					public Database ( string connectionStr )
					{
            //debugGenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf(ref userObj , " CHECK --- nsDb.Database using the following connection string " + connectionStr);
						this.ConnectionString = connectionStr; 
					} //eof constructor 
			protected override string GetConnectionString ( )
			{
				//GenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "In GetConnectionString the ConnectionString is " + this.ConnectionString );
				//GenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "The comming fromURL IS " + commingFromURL );
				return this._ConnectionString;
			} //eof protected override string GetConnectionString()
    } //eof class 

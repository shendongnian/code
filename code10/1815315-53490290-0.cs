    public abstract class SQLConnMgr : Disposable
    {
        SqlConnection dbconn = new SqlConnection();
        protected abstract string DBServer { get;  }
        protected abstract string DBCatalog { get;  }
        protected abstract string DBUser { get;  }
        protected abstract string DBPwd { get;  }
        protected string _Server;
        protected string _Catalog;
        protected string _UserID;
        protected string _Pwd;
        public SQLConnMgr()
        {
            this.SetConnection();
            this.InitClass();
        }
        protected void SetConnection()
        {
            AppSettingsReader reader = new AppSettingsReader();
            this._Server = (string)reader.GetValue(this.DBServer, this._Server.GetType());
            this._Catalog = (string)reader.GetValue(this.DBCatalog, this._Catalog.GetType());
            this._UserID = (string)reader.GetValue(this.DBUser, this._UserID.GetType());
            this._Pwd = (string)reader.GetValue(this.DBPwd, this._Pwd.GetType());
        }
    }
    public class SQLNewDatabaseConnMgr1 : SQLConnMgr
    {
        protected override string DBServer => "DBServer1";
        protected override string DBCatalog => "DBCatalog1";
        protected override string DBUser => "DBUser1";
        protected override string DBPwd => "DBPwd1";
    }
    public class SQLNewDatabaseConnMgr2 : SQLConnMgr
    {
        protected override string DBServer => "DBServer2";
        protected override string DBCatalog => "DBCatalog2";
        protected override string DBUser => "DBUser2";
        protected override string DBPwd => "DBPwd2";
    }

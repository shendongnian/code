    public Enum Role
    {
        Guy = 0,
        Girl = 1
    }
    public partial LINQtoSQLClass
    {
        public ResultObject CreateUser(Role thisRole)
        {
            return CreateUser(Convert.ToInt32(thisRole);
        }
    }

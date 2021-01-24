    public class MySQLClass
    {
        public MySQLClass(IOptions<ConnectionStrings> connectionStrings)
        {
            string unencryptedCS = connectionStrings.Value.connString1;
        }
    }

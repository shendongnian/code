    using Oracle.DataAccess.Client;
        
    public class OracleMgr{
      public OracleMgr(){
        string connectionStr = "Data Source=XE;User Id=user1;Password=abc";
        OracleConnection conn = new OracleConnection(connectionStr);
        do stuff...
      }
    }

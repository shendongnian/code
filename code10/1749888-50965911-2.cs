    public class Database1
    {
        string sCon = string.Empty;
        OracleConnection OraCon;
        protected string query = string.Empty;
        public Database1()
        {
           sCon = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 1.1.1.1)(PORT = 12345)))(CONNECT_DATA =(SID = SIDNAME)));User ID=username;Password=pass;";
           OraCon = new OracleConnection(sCon);
        }
        protected DataTable FillDataTableByParam(OracleParameter[] param)
        {
            DataTable oDT = new DataTable();
            OracleCommand OraCom = new OracleCommand(query, OraCon);
            OraCom.Parameters.AddRange(param);
            new OracleDataAdapter(OraCom).Fill(oDT);
            query = "";
            return oDT;
        }
    }

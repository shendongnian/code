using Oracle.DataAccess.Client;
or
using Oracle.ManagedDataAccess.Client;
....
string oradb = "Data Source=(DESCRIPTION="
	+ "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.158)(PORT=1521)))"
	+ "(CONNECT_DATA=(SERVER=DEDICATED)));"
	+ "User Id=SYSTEM;Password=xxx;";
using (OracleConnection conn = new OracleConnection(oradb)) 
{
	conn.Open();
	using (OracleCommand cmd = new OracleCommand())
	{
		cmd.Connection  = conn;
		cmd.CommandText = "select TABLESPACE_NAME from DBA_DATA_FILES";
		using (OracleDataReader dr = cmd.ExecuteReader())
		{
			while (dr.Read())
			{
				listBox.Items.Add(dr["TABLESPACE_NAME"]);
			}
		}
	}
}

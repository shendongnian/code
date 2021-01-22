using System.Data.SqlClient;
DataTable table = new DataTable("States");
// construct DataTable
table.Columns.Add(new DataColumn("id_state", typeof(int))); 
table.Columns.Add(new DataColumn("state_name", typeof(string)));
// note: if "id_state" is defined as an identity column in your DB,
// row values for that column will be ignored during the bulk copy
table.Rows.Add("1", "Atlanta");
table.Rows.Add("2", "Chicago");
table.Rows.Add("3", "Springfield");
using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
{
  bulkCopy.BulkCopyTimeout = 600; // in seconds
  bulkCopy.DestinationTableName = "state";
  bulkCopy.WriteToServer(table);
}

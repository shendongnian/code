using System.Data.SqlClient;
DataTable table = new DataTable("States");
// construct DataTable
using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
{
  bulkCopy.BulkCopyTimeout = 600; // in seconds
  bulkCopy.DestinationTableName = "state";
  bulkCopy.WriteToServer(table);
}

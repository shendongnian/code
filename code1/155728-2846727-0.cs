using System.IO;
using System.Data;
using System.Data.OleDb;
public DataRow[] GetUsers(string path, string id)
{
  DataTable dt = new DataTable();
  if (File.Exists(path))
  {
    using (OleDbConnection con = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path)))
    {
      OleDbDataAdapter da = new OleDbDataAdapter(string.Format("select * from users", id), con);
      da.Fill(dt);
    }
  }
  string expression = String.Format("{0} = '{1}' and {2} <> ''", id, "first_name", "last_name");
  string sort = "last_name ASC";
  return dt.Select(expression, sort);
}
public DataTable GetUsers(string path, string id)
{
  DataTable dt = new DataTable();
  if (File.Exists(path))
  {
    using (OleDbConnection con = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path)))
    {
      string expression = String.Format("{0} = '{1}' and {2} <> ''", id, "first_name", "last_name");
      OleDbDataAdapter da = new OleDbDataAdapter(expression, con);
      da.Fill(dt);
    }
  }
  return dt;
}</pre>

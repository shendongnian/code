StringBuilder columns = new StringBuilder();
foreach(Percentile p in PercentileConfiguration)
{
    if(columns.ToString().Length > 0) columns.Append(", ");
    columns.Append(p.Percentile);
}
string sql = string.Format("SELECT {0} FROM myTable", columns.ToString());
SqlDataAdapter da = new SqlDataAdapter(sql, connectionString);
...
...
...

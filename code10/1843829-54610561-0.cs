public DataSet FlipDataSet(DataSet my_DataSet)
{
    DataSet ds = new DataSet();
    foreach (DataTable dt in my_DataSet.Tables)
    {
        DataTable table = new DataTable();
        for (int i = 0; i <= dt.Rows.Count; i++)
        {
            table.Columns.Add(Convert.ToString(i));
        }
        DataRow r = null;
        for (int k = 0; k < dt.Columns.Count; k++)
        {
            r = table.NewRow();
            r[0] = dt.Columns[k].ToString();
            for (int j = 1; j <= dt.Rows.Count; j++)
            r[j] = dt.Rows[j - 1][k];
            table.Rows.Add(r);
        }
        ds.Tables.Add(table);
    }
    
    return ds;
}
And where you are binding the data to GridView you have to pass a `DataSet` to the function you can perform like that:
DataSet ds = new DataSet();
if (dt.Rows.Count > 0)
{
    GridView1.DataSource = FlipDataSet(ds.Tables.Add(dt));
    GridView1.DataBind();
}
For more information you can check this article [Displaying vertical rows in a GridView][1]
  [1]: http://aspdotnetcodebook.blogspot.com/2008/04/displaying-vertical-rows-in-gridview.html

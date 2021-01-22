    using System.Data;
    using System.Linq;
    ...
    //assuming 'ds' is your DataSet
    //and that ds has only one DataTable, therefore that table's index is '0'
    DataTable dt = ds.Tables[0];
    DataView dv = new DataView(dt);
    string cols = string.Empty;
    foreach (DataColumn col in dt.Columns)
    {
    if (!string.IsNullOrEmpty(cols)) cols += ",";
    cols += col.ColumnName;
    }
    dt = dv.ToTable(true, cols.Split(','));
    ds.Tables.RemoveAt(0);
    ds.Tables.Add(dt);

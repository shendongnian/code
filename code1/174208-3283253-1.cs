    public static void DataTableToExcel(DataTable tbl)
    {
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        foreach (DataColumn c in tbl.Columns)
        {
            context.Response.Write(c.ColumnName + ";");
        }
        context.Response.Write("\n");
        foreach (DataRow r in tbl.Rows)
        {
            for (int i = 0; i < tbl.Columns.Count; i++)
            {
                context.Response.Write(r[i].ToString().Replace(";", string.Empty) + ";");
            }
            context.Response.Write("\n");
        }
        context.Response.ContentType = "text/csv";
        context.Response.AppendHeader("Content-Disposition",
            "attachment; filename=export.csv");
        context.Response.End();
    }

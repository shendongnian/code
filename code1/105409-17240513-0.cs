    // Example data
    DataTable table = new DataTable();
    table.Columns.AddRange(new[]{ new DataColumn("Key"), new DataColumn("Value") });
    foreach (string name in Request.ServerVariables)
        table.Rows.Add(name, Request.ServerVariables[name]);
    // This actually makes your HTML output to be downloaded as .xls file
    Response.Clear();
    Response.ClearContent();
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xls");
    // Create a dynamic control, populate and render it
    GridView excel = new GridView();
    excel.DataSource = table;
    excel.DataBind();
    excel.RenderControl(new HtmlTextWriter(Response.Output));
    Response.Flush();
    Response.End();

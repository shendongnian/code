    <%
    var tbl = ViewData["MyDataTable"];
    
    foreach (DataRow row in tbl.Rows)
    {
      foreach (DataColumn col in tbl.Columns)
      {
        Response.Write(row[col] as string ?? string.Empty);
      }
    }
    %>

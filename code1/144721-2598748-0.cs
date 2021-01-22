    string docName  = "MyExcelDoc"
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("AAAAAA");
    sb.AppendLine("BBBBBB");
    
    context.Response.ClearContent();
    context.Response.ContentType = "text/csv";
    context.Response.AddHeader("content-disposition", "attachment; filename=" + docName + ".csv");
    context.Response.Write(sb.ToString());            
    context.Response.Flush();

    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.ContentType = "application/ms-excel";
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

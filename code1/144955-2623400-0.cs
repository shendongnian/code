    string FilePath = MapPath("your.pdf");
    Response.ContentType = "Application/pdf";
    Response.AppendHeader( "content-disposition", "attachment; filename=" + FilePath);
    Response.WriteFile(FilePath);
    Response.End();

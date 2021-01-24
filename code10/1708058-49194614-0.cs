    Response.ContentType = "Application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
    Response.TransmitFile(filename);
    //Response.Flush(); no need for flush, Response.End will do it
    Response.End();

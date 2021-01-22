    Response.Clear();
    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // Excel 2007 format
    // ... doing work...
    Response.AddHeader("Content-Length", outputFileInfo.Length.ToString());
    Response.TransmitFile(outputFileInfo.ToString());
    HttpContext.Current.Response.End(); // <--This seems to be the only major difference

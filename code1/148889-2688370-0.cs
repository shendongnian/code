    Response.ContentType = "text/xml";
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
    string path = Server.MapPath("~/" + FileName);
    byte[] data = File.ReadAllBytes(path);
    File.Delete(path);
    Response.BinaryWrite(data);
    Response.End();

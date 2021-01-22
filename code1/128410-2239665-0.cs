    Response.Clear();
    Response.ClearHeaders();
    Response.ContentType = file.ContentType;
    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.FileName + "\"");
    Response.AddHeader("Content-Length", file.FileSize.ToString());
    Response.OutputStream.Write(file.Bytes, 0, file.Bytes.Length);
    Response.Flush();
    Response.End();

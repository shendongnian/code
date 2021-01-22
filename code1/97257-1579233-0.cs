    Response.Clear();
    Response.AddHeader("Content-Length", fileContents.Length.ToString());
    Response.AddHeader("Content-Disposition", "attachment; filename=FILENAME");
    Response.OutputStream.Write(fileContents, 0, fileContents.Length);
    Response.Flush();
    Response.End();

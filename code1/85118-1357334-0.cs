    sender.Response.Clear();
    sender.Response.ContentType = uf.FileType; // the binary data
    sender.Response.AddHeader("Content-Disposition", "attachment; filename="
             + uf.FileName);
    sender.Response.BinaryWrite(uf.FileData);
    sender.Response.Close();

    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition",
        "attachment; filename=\"" + Path.GetFileName(path) + "\"");
    Response.TransmitFile(path);
    Response.End();

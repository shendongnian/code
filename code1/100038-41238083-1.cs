    Response.AddHeader("Content-Type", "application/pdf");
    Response.AddHeader("Content-Length", base64Result.Length.ToString());
    Response.AddHeader("Content-Disposition", "inline;");
    Response.AddHeader("Cache-Control", "private, max-age=0, must-revalidate");
    Response.AddHeader("Pragma", "public");
    Response.BinaryWrite(Convert.FromBase64String(base64Result));

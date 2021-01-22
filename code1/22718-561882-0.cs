    byte[] downloadBytes = doc.GetData();
    Response.ClearContent();
    Response.ClearHeaders();
	
    Response.Buffer = true;
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Length", downloadBytes.Length.ToString());
    Response.AddHeader("Content-Disposition", "attachment; filename=myFile.pdf");
    Response.BinaryWrite(downloadBytes);
    Response.Flush();
    Response.End();

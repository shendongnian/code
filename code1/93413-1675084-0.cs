    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-disposition", "attachment; filename=file.pdf"); // open in a new window
    Response.OutputStream.Write(outStream.GetBuffer(), 0, outStream.GetBuffer().Length);
    Response.Flush();
    // For some reason, if we close the Response stream, the PDF doesn't make it through
    //Response.Close();

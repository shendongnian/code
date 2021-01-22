        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Length", buffer.Length.ToString());
        Response.BinaryWrite(buffer);
        //End the response
        Response.End();
        streamDoc.Close();

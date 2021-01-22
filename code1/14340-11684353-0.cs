        FileStream objFileStream = File.Open(Server.MapPath("TextFile.txt"), FileMode.Open);
        Response.Write(string.Format("FileStream Content length: {0}", objFileStream.Length.ToString()));
        MemoryStream objMemoryStream = new MemoryStream();
        // Copy File Stream to Memory Stream using CopyTo method
        objFileStream.CopyTo(objMemoryStream);
        Response.Write("<br/><br/>");
        Response.Write(string.Format("MemoryStream Content length: {0}", objMemoryStream.Length.ToString()));
        Response.Write("<br/><br/>");

    context.Response.ContentType = "image";
    using (System.IO.MemoryStream str = new System.IO.MemoryStream(objData.ToArray(), true))
    {
           str.Write(objData.ToArray(), 0, objData.ToArray().Length);
           Byte[] bytes = str.ToArray();
           context.Response.BinaryWrite(bytes);
    }

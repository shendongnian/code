    using (System.IO.FileStream stream = System.IO.File.Create("c:\\temp\\file.pdf"))
    {
        System.Byte[] byteArray = System.Convert.FromBase64String(base64BinaryStr);
        stream.Write(byteArray, 0, byteArray.Length);
    }

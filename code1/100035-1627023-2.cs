    using (FileStream stream = System.IO.File.Create("c:\\file.pdf"))
    {
        byte[] byteArray = Convert.FromBase64String(base64BinaryStr);
        stream.Write(byteArray, 0, byteArray.Length);
    }

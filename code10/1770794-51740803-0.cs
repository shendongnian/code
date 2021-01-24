    using ExcelDataReader;
    using (MemoryStream ms = new MemoryStream())
    using (CryptoStream sc = new CryptoStream(ms, new 
    FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces), CryptoStreamMode.Write))
    using (StreamWriter sw = new StreamWriter(cs))
    {
        sw.Write(base64String);
        sw.Flush;
        using (IExcelDataReader er = ExcelReaderFactory.CreateBinaryReader(ms))
        {
            while(er.Read())
            {
                for (int i = 0; i < er.FieldCount; i++)
                    Console.Write(er.GetValue(i) + " ");
                Console.WriteLine();
            }
        }
    }

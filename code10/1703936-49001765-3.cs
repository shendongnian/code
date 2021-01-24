    byte[] input;
    using (var ms = new MemoryStream()) {
        using (var cs = new CryptoStream(ms, new FromBase64Transform(), CryptoStreamMode.Write)) {
            using (var tr = new StreamWriter(cs)) {
                tr.Write(data);
                tr.Flush();
                input = ms.ToArray();
            }
        }
    }
    using (var ms = new MemoryStream(input)) {
        using (var reader = new StreamReader(ms, Encoding.GetEncoding(1251), true)) {
            string csv = reader.ReadToEnd();
            //OR
            //while (!reader.EndOfStream) {
            //    var line = reader.ReadLine();
            //}
        }
    }

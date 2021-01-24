    using (var ms = new MemoryStream()) {
        using (var cs = new CryptoStream(ms, new FromBase64Transform(), CryptoStreamMode.Write)) {
            using (var tr = new StreamWriter(cs)) {
                tr.Write(data);
                tr.Flush();
                ms.Position = 0;
                using (var reader = new StreamReader(ms, Encoding.GetEncoding(1251), true)) {
                    string csv = reader.ReadToEnd();
                    //OR
                    //while (!reader.EndOfStream) {
                    //    var line = reader.ReadLine();
                    //}
                }
            }
        }
    }

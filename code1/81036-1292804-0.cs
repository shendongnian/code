       // Specify the code page to correctly interpret byte values
        Encoding encoding = Encoding.GetEncoding(737); //(DOS) Greek code page
        byte[] codePageValues = System.IO.File.ReadAllBytes(@"greek.txt");
        // Same content is now encoded as UTF-16
        string unicodeValues = encoding.GetString(codePageValues);

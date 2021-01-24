    using (var output = new BinaryWriter(File.Create("rsa.pvk")))
    {
        output.Write(0xB0B5F11Eu);  // PVK magic number
        output.Write(0u);
        output.Write(1u);           // KEYTYPE_KEYX for RSA
        output.Write(0u);           // not encrypted
        output.Write(0u);           // encryption salt length
        var cspBlob = rsaCSP.ExportCspBlob(true);
        output.Write((uint)cspBlob.Length);
        output.Write(cspBlob);
    }

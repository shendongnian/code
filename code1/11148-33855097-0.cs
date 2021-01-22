    using(var input = File.OpenRead(...))
    using(var output = File.Create(...))
    {
        // if there are additional headers before the zlib header, you can skip them:
        // input.Seek(xxx, SeekOrigin.Current);
        if (input.ReadByte() != 0x78 || input.ReadByte() != 0x9C)//zlib header
            throw new Exception("Incorrect zlib header");
        using (var deflateStream = new DeflateStream(decryptedData, CompressionMode.Decompress, true))
        {
            deflateStream.CopyTo(output);
        }
    }

    var encoding = Encoding.GetEncoding(response.CharacterSet);
    byte[] preamble = encoding.GetPreamble();
    bool hasPreamble = bytes.Take(preamble.Length).SequenceEqual(preamble);
    if (hasPreamble)
    {
        File.WriteAllBytes("WithPreambleFile.txt", bytes);
        using (var fs = File.OpenWrite("WithoutPreamble.txt"))
        {
            fs.Write(bytes, preamble.Length, bytes.Length - preamble.Length);
        }
    }
    else
    {
        File.WriteAllBytes("WithoutPreambleFile.txt", bytes);
        using (var fs = File.OpenWrite("WithPreamble.txt"))
        {
            fs.Write(preamble, 0, preamble.Length);
            fs.Write(bytes, 0, bytes.Length);
        }
    }

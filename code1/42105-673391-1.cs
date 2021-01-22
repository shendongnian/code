    // I DON'T RECOMMEND THIS!!!!
    byte[] preamble = lastEncoding.GetPreamble(),
        content = lastEncoding.GetBytes(text);
    byte[] raw = new byte[preamble.Length + content.Length];
    Buffer.BlockCopy(preamble, 0, raw, 0, preamble.Length);
    Buffer.BlockCopy(content, 0, raw, preamble.Length, content.Length);
    text = nextEncoding.GetString(raw);

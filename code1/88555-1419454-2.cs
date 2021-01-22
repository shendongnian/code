    if (Clipboard.ContainsImage())
    {
        using (MemoryStream memory = new MemoryStream())
        {
            using (Image img = Clipboard.GetImage())
            {
                img.Save(memory, img.RawFormat);
            }
            string base64 = Convert.ToBase64String(memory.ToArray());
            Clipboard.SetText(base64);
        }
    }

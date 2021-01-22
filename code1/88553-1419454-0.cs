    if (System.Windows.Forms.Clipboard.ContainsImage())
    {
        MemoryStream memory = new MemoryStream();
        Image img = System.Windows.Forms.Clipboard.GetImage();
        img.Save(memory, img.RawFormat);
        string base64 = Convert.ToBase64String(memory.ToArray());
        System.Windows.Forms.Clipboard.SetText(base64);
    }

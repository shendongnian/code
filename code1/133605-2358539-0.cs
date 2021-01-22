    shape.Copy();
    bool imgOk = Clipboard.ContainsImage();
    if (imgOk)
    {
        Image img = Clipboard.GetImage();
        MessageBox.Show(imgOk.ToString());
        string filepath = @"c:\temp\img.jpg";
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        img.Save(filepath);
    }

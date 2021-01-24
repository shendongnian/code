    String[] lines = File.ReadAllLines(path);
    using (Bitmap img = GrayImageFromCsv(lines, 3))
    {
        // null = conversion failed. Could log/show warning.
        if (img != null)
            img.Save("fromcsv.png", ImageFormat.Png);
    }

    public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
    
    private void button_Click(object sender, RoutedEventArgs e)
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var files = Directory.GetFiles(folder);
        foreach(var f in files)
        {
            if (ImageExtensions.Contains(Path.GetExtension(f).ToUpperInvariant()))
            {
                // process image
            }
        }
    }

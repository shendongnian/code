    public Stream GetImageData(string inputFile, string dcRawExe)
    {
            
        var startInfo = new ProcessStartInfo(dcRawExe)
        {
            Arguments = "-c -e \"" + inputFile + "\"",
            RedirectStandardOutput = true,
            UseShellExecute = false
        };
        var process = Process.Start(startInfo);
        var image = Image.FromStream(process.StandardOutput.BaseStream);
        var memoryStream = new MemoryStream();
        image.Save(memoryStream, ImageFormat.Png);
        return memoryStream;
    }

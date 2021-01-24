    /// <summary>
    /// The command line arguments for generating a thumbnail
    /// 
    /// {0} is the input source path
    /// {1} is the output destination folder path
    /// {2} is the output horizontal resolution
    /// {3} is the output vertical resolution
    /// </summary>
    private const string ThumbnailArguments = " -dBATCH -dNOPAUSE -sDEVICE=jpeg -dJPEGQ=95 -sOutputFile=\"{1}\\%03d.jpg\" \"{0}\"";
    // Build the command line arguments
    var arguments = string.Format(ThumbnailArguments, inputPath, outputFolderPath, imageWidth, imageHeight);
    // Create the process to generate the thumbnail
    using (var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "C:\\gswin64c.exe",
            Arguments = arguments,
            CreateNoWindow = true
        }
    })
    {
        // Attempt to start the process
        if (!process.Start())
            return;
        // Wait for the process to finish
        process.WaitForExit();
    }

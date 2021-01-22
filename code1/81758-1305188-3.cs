    bool ret;
    TryCatch(
        () =>
            {
                Directory.CreateDirectory(directory);
                ret = true;
            },
        new[]
            {
                typeof (IOException), typeof (UnauthorizedAccessException), typeof (PathTooLongException),
                typeof (DirectoryNotFoundException), typeof (NotSupportedException)
            },
        ex => lblBpsError.Text = ex.Message
    );
    
    return ret;

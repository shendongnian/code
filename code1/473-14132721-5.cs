    private void Sample(string filePath)
    {
        Stream stream = null;
        try
        {
            var timeOut = TimeSpan.FromSeconds(1);
            if (!TryOpen(filePath,
                         FileMode.Open,
                         FileAccess.ReadWrite,
                         FileShare.ReadWrite,
                         timeOut,
                         out stream))
                return;
            // Use stream...
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    }

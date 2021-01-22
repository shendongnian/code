    private static async Task AppendLineToFileAsync([NotNull] string path, string line)
    {
        if (string.IsNullOrWhiteSpace(path)) 
            throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitepsace.");
    
        if (!File.Exists(path)) 
            throw new FileNotFoundException("File not found.", nameof(path));
            
        using (var file = File.Open(path, FileMode.Append, FileAccess.Write))
        using (var writer = new StreamWriter(file))
        {
            await writer.WriteLineAsync(line);
            await writer.FlushAsync();
        }
    }

    private async Task DoWorkAsync(string InputDirectory)
    {
        var files = System.IO.Directory.GetFiles(InputDirectory);
        for (int i = 0; i < files.Length; i++)
        {
            await Task.Run(() => readFile.Read(files[i], Dictionary, Output));
            ProgressBar.Value = ((i + 1) * 100) / files.Length;
        }
    }

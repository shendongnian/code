    public async Task loadTitles(IProgress<int> progress, CancellationToken ct, ProgressBar prg)
    {
        foreach (var line in System.IO.Directory.EnumerateFiles(GlobalData.Config.DataPath, "*.jpg", SearchOption.AllDirectories))
        {
            if (ct.IsCancellationRequested)
            {
                break;
            }
    
            // ... the rest of your code
        }
    }

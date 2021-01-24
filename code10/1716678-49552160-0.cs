    private void CreateFile(object sender, FileSystemEventArgs e)
    {
        int until = 5;
        int i = 0;
        bool success = false;
        while (!success && i < until)
        {
            try
            {
                path = String.Format(e.FullPath);
                filename = Path.GetFileName(path);
                using (Stream fs = File.OpenRead(@path);)
                {
                    SPAPI spobj = new SPAPI();
                    spobj.SPUploader(fs, filename);
                }
                success = true;
            }
            catch
            {
                i++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }

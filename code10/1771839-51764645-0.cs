    private void Button (object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                var files = Directory.GetFiles(startPath, "*" + filetype, SearchOption.AllDirectories);
                int max = files.Length;
                int i = 0;
                            
            foreach (var file in files)
            {
                File.Copy(file, tempPath + @"\" + System.IO.Path.GetFileName(file));
                backgroundWorker1.ReportProgress((i * 100) / max);
                i++;
            }
        }

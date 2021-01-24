    private void Btn_Compare_Click(object sender, RoutedEventArgs e)
    {
        CountFilesAsync(Progress<string>(FileCount));
    }
    private async void CountFilesAsync(IProgress<string> progress)
    {
        await Task.Run(() =>
            {
                System.IO.DirectoryInfo myDir = new System.IO.DirectoryInfo(path);
                foreach (FileInfo item in myDir.GetFiles())
                {
                    progress(item.Name); // report progress
                } 
            });
    }

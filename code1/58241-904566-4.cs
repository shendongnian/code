    private void btnOpen_Click(object sender, EventArgs e)
    {
        string path = BrowseForFolder();
        if (path != string.Empty)
        {
            ListDirectoryContent(path);
        }
    }
    
    private string BrowseForFolder()
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        if (fbd.ShowDialog() == DialogResult.OK)
        {
            return fbd.SelectedPath;
        }
        return string.Empty;
    }
    
    private void ListDirectoryContent(string path)
    {
        label1.Text = path;
        listView1.Items.Clear();
        DirectoryInfo di = new DirectoryInfo(path);
        // first list sub-directories
        DirectoryInfo[] dirs = di.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            listView1.Items.Add(dir.Name);
        }
        // then list the files
        FileInfo[] files = di.GetFiles();
        foreach (FileInfo file in files)
        {
            listView1.Items.Add(file.Name);
        }
    
    }

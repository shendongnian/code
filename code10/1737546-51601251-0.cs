    /// <summary>
    /// Looks for the vlc directory on the opening of the app
    /// Opens a dialog if the libvlc folder is not found for the user to pick the good one
    /// Folder for 32bits should be "libvlc\win-x86\" and "libvlc\win-x64\" for 64 bits
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void myVlcControl_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
    {
        var currentAssembly = Assembly.GetEntryAssembly();
        var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
    
        if (currentDirectory == null)
            return;
        if (IntPtr.Size == 4)
            e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
        else
            e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));
    
        if (!e.VlcLibDirectory.Exists)
        {
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "Select Vlc libraries folder.";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            }
        }
    }

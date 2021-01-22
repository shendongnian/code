 private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                TreeViewItem drive = new TreeViewItem();
                drive.Header = di.Name;
                treeView1.Items.Add(drive);
                DirectoryInfo folders = new DirectoryInfo(di.Name);
                // The depth count means that it only goes 3 levels deep, to make it quick to load
                GetFoldersAndFiles(drive, folders, 3);
            }
        }
        private static void GetFoldersAndFiles(TreeViewItem parent, DirectoryInfo folders, int depth)
        {        
            if ((depth > 0)
            {
                foreach (DirectoryInfo dirI in folders.GetDirectories())
                {
                    TreeViewItem dir = new TreeViewItem();
                    dir.Header = dirI.Name;
                    parent.Items.Add(dir);
                    GetFoldersAndFiles(dir, dirI, depth - 1);
                }
                foreach (FileInfo fileI in folders.GetFiles())
                {
                    TreeViewItem file = new TreeViewItem();
                    file.Header = fileI.Name;
                    parent.Items.Add(file);
                }
            }
        }

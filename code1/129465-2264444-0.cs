    // Handle the BeforeExpand event
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
       if (e.Node.Tag != null) {
           AddDirectoriesAndMusicFiles(e.Node, (string)e.Node.Tag);
       }
    }
    
    private void AddDirectoriesAndMusicFiles(TreeNode node, string path)
    {
        node.BeginUpdate(); // for best performance
        node.Nodes.Clear(); // clear dummy node if exists
    
        try {
            DirectoryInfo currentDir = new DirectoryInfo(path);
            DirectoryInfo[] subdirs = currentDir.GetDirectories();
    
            foreach (DirectoryInfo subdir in subdirs) {
                TreeNode child = new TreeNode(subdir.Name);
                child.Tag = subdir.FullName; // save full path in tag
                // TODO: Use some image for the node to show its a music file
    
                // if have subdirs, add dummy node
                // to display the [+] allowing expansion
                if (subdir.GetDirectories().Length > 0) {
                    child.Nodes.Add(new TreeNode()); 
                }
                node.Nodes.Add(child);
            }
    
            List<FileInfo> files = new List<FileInfo>();
            files.AddRange(currentDir.GetFiles("*.mp3"));
            files.AddRange(currentDir.GetFiles("*.aiff"));
            files.AddRange(currentDir.GetFiles("*.wav")); // etc
    
            foreach (string file in files) {
                TreeNode child = new TreeNode(Path.GetFileName(file));
                // TODO: Use some image for the node to show its a music file
                child.Tag = file; // save full path for later use
                node.Nodes.Add(child);
            }
    
        } catch (UnauthorizedAccessException) { // ignore dir
        } finally {
            node.EndUpdate(); // need to be called because we called BeginUpdate
            node.Tag = null; // clear tag
        }
    }
    
    private void MainForm_Load(object sender, EventArgs e)
    {
        foreach (DriveInfo d in DriveInfo.GetDrives()) {
            TreeNode root = new TreeNode(d.Name);
            root.Tag = d.Name; // for later reference
            // TODO: Use Drive image for node
            treeView1.Nodes.Add(root);
        }
    }

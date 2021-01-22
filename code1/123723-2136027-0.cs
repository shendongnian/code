    // Handle the BeforeExpand event
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
       if (e.Node.Tag != null) {
           AddTopDirectories(e.Node, (string)e.Node.Tag);
       }
    }
    
    private void AddTopDirectories(TreeNode node, string path)
    {
        node.BeginUpdate(); // for best performance
        node.Nodes.Clear(); // clear dummy node if exists
        
        try {
            string[] subdirs = Directory.GetDirectories(path);
            result = new TreeNode(path);
            
            foreach (string subdir in subdirs) {
                TreeNode child = new TreeNode(subdir);
                child.Tag = subdir; // save dir in tag
    
                // if have subdirs, add dummy node
                // to display the [+] allowing expansion
                if (Directory.GetDirectories(subdir).Length > 0) {
                    child.Nodes.Add(new TreeNode()); 
                }
            }
        } catch (UnauthorizedAccessException) { // ignore dir
        } finally {
            node.EndUpdate(); // need to be called because we called BeginUpdate
            child.Tag = null; // clear tag
        }
    }

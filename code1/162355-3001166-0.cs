        public void BindDirectoryToTreeView(string directoryPathToBind)
        {
            TreeNode rootNode = new TreeNode();
            treeView1.Nodes.Add(rootNode);
            RecurseFolders(directoryPathToBind, rootNode);
        }
        public void RecurseFolders(string path, TreeNode node)
        {
            var dir = new DirectoryInfo(path);
            node.Text = dir.Name;
            try
            {
                foreach (var subdir in dir.GetDirectories())
                {
                    var childnode = new TreeNode();
                    node.Nodes.Add(childnode);
                    RecurseFolders(subdir.FullName, childnode);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // TODO:  write some handler to log and/or deal with 
                // unauthorized exception cases
            }
            foreach (var fi in dir.GetFiles().OrderBy(c=>c.Name))
            {
                var fileNode = new TreeNode(fi.Name);
                node.Nodes.Add(fileNode);
            }
        }
You would invoke the code by calling BindDirectoryToTreeView("c:\\"); for instance.  Note that you should have a treeview named treeView1 on the form that has this code.  

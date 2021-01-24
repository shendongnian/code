    private void button1_Click(object sender, EventArgs e)
        {
            treeView1.ShowNodeToolTips = true;
            DirectoryInfo d = new DirectoryInfo("C:\\projects");
            GetAllDirectories(d, null);
        }
        void GetAllDirectories(DirectoryInfo d, TreeNode nodeToAddChilds)
        {
            if (treeView1.Nodes.Count == 0)
            {
                TreeNode root = new TreeNode();
                root.ToolTipText = GetFileNames(d);
                root.Text = d.Name;
                treeView1.Nodes.Add(root);
                nodeToAddChilds = root;
            }
            DirectoryInfo[] dirList = d.GetDirectories();
            foreach (DirectoryInfo oneDir in dirList)
            {
                if (oneDir.Name.StartsWith("$"))
                {
                    // Just to avoid system permission limitations
                    continue;
                }
                TreeNode newChild = new TreeNode();
                newChild.ToolTipText = GetFileNames(oneDir);
                newChild.Text = oneDir.Name;
                nodeToAddChilds.Nodes.Add(newChild);
                GetAllDirectories(oneDir, newChild);
            }
        }
        string GetFileNames(DirectoryInfo d)
        {
            string files = "files:\r\n";
            FileInfo[] allFiles = d.GetFiles();
            foreach (FileInfo oneFile in allFiles)
            {
                files += oneFile.Name + "\r\n";
            }
            return files;
        }

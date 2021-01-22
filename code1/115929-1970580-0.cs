    private void button1_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog() != DialogResult.OK) { return; }
        this.treeView1.Nodes.Add(TraverseDirectory(dialog.SelectedPath));
    }
   
    private TreeNode TraverseDirectory(string path)
    {
        TreeNode result = new TreeNode(path);
        foreach (var subdirectory in Directory.GetDirectories(path))
        {
            result.Nodes.Add(TraverseDirectory(subdirectory));
        }
        return result;
    }

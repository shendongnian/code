    class myTreeNode : TreeNode
    {
       public string FilePath;
    
       public myTreeNode(string fp)
       {
          FilePath = fp;
          this.Text = fp.Substring(fp.LastIndexOf("\\"));
       }
    }

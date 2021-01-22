    private void AddFiles()
    {
      // Iterate your list with FileInfos here
      foreach( var fileInfo in new Collection<FileInfo>() )
      {
        GetOrCreateTreeNode( fileInfo.Directory ).Nodes.Add( new TreeNode( fileInfo.Name ) );
      }
    }
    private TreeNode GetOrCreateTreeNode( DirectoryInfo directory )
    {
      if( directory.Parent == null )
      {
        var rootNode = Directories.Nodes[directory.Name];
        if( rootNode == null )
        {
          rootNode = new TreeNode(directory.Name);
          // Access your TreeView control here:
          <TreeView>.Nodes.Add( rootNode );
        }
        return rootNode;
      }
      var parent = GetOrCreateTreeNode( directory.Parent );
      var node = parent.Nodes[directory.Name];
      if( node == null )
      {
        node = new DirectoryNode( directory );
        parent.Nodes.Add( node );
      }
      return node;
    }

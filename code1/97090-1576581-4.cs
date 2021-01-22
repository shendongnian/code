    TreeNode node1 = new TreeNode( "Node 1" );          
    TreeNode node2 = new TreeNode( "Node 2" );                          
    treeView1.Nodes.Add( node1 );
    treeView1.Nodes.Add( node2 );
    
    treeView1.Nodes.Clear( );
    treeView1.Nodes.Add( "Node 1" );
    treeView1.Nodes.Add( "Node 2" );
    var matches = from TreeNode x in treeView1.Nodes
                  where x.Text == node2.Text
                  select x;
    treeView1.SelectedNode = matches.First<TreeNode>( );
    // now correctly selects Node2
    MessageBox.Show( treeView1.SelectedNode.ToString( ) );

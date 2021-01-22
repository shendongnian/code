        class ValueAndIsFile {
            public bool IsFile {get; set;}
            public object Value {get; set}
        }
        
        ...
        
        TreeNode nd =  new TreeNode ();
        nd.Value = new ValueAndIsFile(){ IsFile = true, Value = yourValueObject};
        treeView.Nodes.Add(nd);
        
        ....
        
        protected void treeview_Navigation_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = treeview_Navigation.SelectedNode;
            ValueAndIsFile val = node.Value as  ValueAndIsFile ; 
        if (val !=null)
            Response.Write(val.IsFile.ToString());
        else
            throw new Exception("What this node doing here?");
    }

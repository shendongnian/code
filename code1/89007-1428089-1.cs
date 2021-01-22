    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        object[] args = e.UserState as object[];
        TreeListNode parentNode = args[0] as TreeListNode;
        string percentMsg = args[1].ToString(); //node: n/n message
    
        parentNode.Nodes[0].SetValue(0, percentMsg); //change "Loading.." to "node: n/n"
        parentNode.TreeView.Update(); // or Form.Update
    }

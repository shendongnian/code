    //untested
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    //    t.Invoke(new MethodInvoker( () => AddSubNodes(e.Argument) ));
        object[] args = arg as object[];
        TreeListNode parentNode = e;
    
        var newNodes = new List<TreeNode>();
        int nodeCount = 10;
        for (int i = 0; i < nodeCount; i++)
        {
           // t.AppendNode(new object[] { "node cell text" }, parentNode);
            newNodes.Add(new object[] { "node cell text" }); // ???
            bw.ReportProgress(i, new object[]{ parentNode, "node: " + i.ToString() + "/" + nodeCount.ToString()});
        }
          
        e.Result = e.Argument;
        e.Result = newNodes;
    }

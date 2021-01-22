    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == MouseButtons.Right)  
        {  
            MessageBox.Show(string.Format("Node clicked: {0}", e.Node.Text));  
        }  
    }

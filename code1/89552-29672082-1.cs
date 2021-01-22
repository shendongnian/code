    private void CheckUnCheck(object sender)
            {
                if ((sender as TreeView).SelectedNode.Checked == true)
                    foreach (TreeNode tr in (sender as TreeView).SelectedNode.ChildNodes)
                    {
                        foreach (TreeNode child in tr.ChildNodes)
                            child.Checked = true;
                        tr.Checked = true;
                    }
                else
                    foreach (TreeNode tr in (sender as TreeView).SelectedNode.ChildNodes)
                    {
                        foreach (TreeNode child in tr.ChildNodes)
                            child.Checked = false;
                        tr.Checked = false;
                    }
            }

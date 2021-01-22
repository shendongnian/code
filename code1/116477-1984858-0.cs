    private int _callCountUp;
            private int _callCountDn;
    private void tvwPermissions_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
            {
                bool anyChecked = false;
    
                if (_callCountDn == 0 && e.Node.Parent != null)
                {
                    anyChecked = false;
                    foreach (TreeNode childNode in e.Node.Parent.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            anyChecked = true;
                            break;
                        }
                    }
                    _callCountUp += 1;
    
                    if (anyChecked)
                        e.Node.Parent.Checked = true;
    
                    _callCountUp -= 1;
                }
    
                if (_callCountUp == 0)
                {
                    foreach (TreeNode childNode in e.Node.Nodes)
                    {
                        _callCountDn += 1;
                        childNode.Checked = e.Node.Checked;
                        _callCountDn -= 1;
                    }
                }
            }

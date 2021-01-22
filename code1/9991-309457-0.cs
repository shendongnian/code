        private void treeView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                    string text = GetNodeTooltip(node);
                    string currentText = toolTip1.GetToolTip(treeView1);
                    if (text.Equals(currentText) == false)
                    {
                        toolTip1.SetToolTip(treeView1, text);
                    }
                }
                else
                {
                    toolTip1.SetToolTip(tree, string.Empty);
                }
            }
            else
            {
                toolTip1.SetToolTip(tree, string.Empty);
            }
        }

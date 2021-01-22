        private void button2_Click(object sender, EventArgs e)
        {
            int grandTotal = CalculateNodes(this.treeView1.Nodes);
        }
        private int CalculateNodes(TreeNodeCollection nodes)
        {
            int grandTotal = 0;
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    int childTotal = CalculateNodes(node.Nodes);
                    node.Text = childTotal.ToString();
                    grandTotal += childTotal;
                }
                else
                {
                    grandTotal += Convert.ToInt32(node.Text);
                }
            }
            return grandTotal;
        }

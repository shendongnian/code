        private void button1_Click(object sender, EventArgs e)
        {
            btnCreateTreeData();
        }
        private void btnCreateTreeData()
        {
            // create buffer for storing string data
            System.Text.StringBuilder buffer = new System.Text.StringBuilder();
            // loop through each of the treeview's root nodes
            foreach (TreeNode rootNode in treeView1.Nodes)
                // call recursive function
                BuildTreeString(rootNode, ref buffer);
            // write data to file
            System.IO.File.WriteAllText(@"D:\treeTest.txt", buffer.ToString());
        }
        private void BuildTreeString(TreeNode rootNode, ref System.Text.StringBuilder buffer)
        {
            buffer.Append(rootNode.Text);
            buffer.Append(Environment.NewLine);
            foreach (TreeNode childNode in rootNode.Nodes)
                BuildTreeString(childNode, ref buffer);
        }

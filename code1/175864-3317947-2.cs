        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++) {
                TreeNode node = treeView1.Nodes.Add(i.ToString());
                for (int j = 0; j < 10; j++) {
                    node.Nodes.Add(j.ToString());
                }
            }
        }
        private void ScrollNode(TreeNode node) {
            treeView1.TopNode = node;
            treeView1.Refresh();
            System.Threading.Thread.Sleep(50);
            if (node.IsExpanded) {
                foreach (TreeNode subNode in node.Nodes)
                    ScrollNode(subNode);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Focus();
            foreach (TreeNode node in treeView1.Nodes) {
                ScrollNode(node);
            }
        }

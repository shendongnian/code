        private void button1_Click(object sender, EventArgs e) {
            List<String> paths = new List<String> { 
                "Root", "Root/Item1", "Root/Item2", "Root/Item3/SubItem1", 
                "Root/Item3/SubItem2", "Root/Item4/SubItem1", "AnotherRoot"
            };
            List<TreeNode> nodeCollection = new List<TreeNode>();
            foreach (var path in paths) {
                AddPath(nodeCollection, path);
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.AddRange(nodeCollection.ToArray());
        }
        public void AddPath(List<TreeNode> collection, String path) {
            LinkedList<String> pathToBeAdded = new LinkedList<String>(path.Split(new String[] { @"/" }, StringSplitOptions.RemoveEmptyEntries));
            
            if (pathToBeAdded.Count == 0) {
                return;
            }
            String rootPath = pathToBeAdded.First.Value;
            TreeNode root = collection.FirstOrDefault(n => n.Text.Equals(rootPath));
            if (root == null) {
                root = new TreeNode(rootPath);
                collection.Add(root);
            }
            pathToBeAdded.RemoveFirst();
            AddPath(root, pathToBeAdded);
        }
        public void AddPath(TreeNode rootNode, LinkedList<String> pathToBeAdded) {
            if (pathToBeAdded.Count == 0) {
                return;
            }
            
            String part = pathToBeAdded.First.Value;
            TreeNode subNode = null;
            if (!rootNode.Nodes.ContainsKey(part)) {
                subNode = rootNode.Nodes.Add(part, part);
            } else {
                subNode = rootNode.Nodes[part];
            }
            pathToBeAdded.RemoveFirst();
            AddPath(subNode, pathToBeAdded);
        }

        public void AddItem(TreeView treeControl, TreeNode parent, string item)
        {
            TreeNodeCollection nodesRef = (parent != null) ? parent.Nodes : treeControl.Nodes;
            string currentNodeName;
            if (-1 == item.IndexOf('/')) currentNodeName = item;
            else  currentNodeName = item.Substring(0, item.IndexOf('/'));
            if (nodesRef.ContainsKey(currentNodeName))
            {
                AddItem(treeControl, nodesRef[currentNodeName], item.Substring(currentNodeName.Length+1));
            }
            else
            {
                TreeNode newItem = nodesRef.Add(currentNodeName, currentNodeName);
                if (item.Length > currentNodeName.Length)
                {
                    AddItem(treeControl, newItem, item.Substring(item.IndexOf('/', currentNodeName.Length) + 1));
                }
            }
        }

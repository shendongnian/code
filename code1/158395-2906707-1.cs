        private void AddTreeViewNode(Message msg) 
        { 
            TreeNode newNode = new TreeNode(msg.SeqNum); 
 
            nodeQueue.Add(newNode); 
 
            if (nodeQueue.Count == 1000) 
            { 
                var buffer = nodeQueue.ToArray(); 
                nodeQueue.Clear(); 
                Invoke(new Action(() => 
                    { 
                        treeView1.BeginUpdate(); 
                        treeView1.Nodes.AddRange(buffer); 
                        treeView1.EndUpdate(); 
                    }));
                System.Threading.Thread.Sleep(500); 
            } 
        }

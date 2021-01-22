    List<TreeNode> nodes = new List<TreeNode>();
    Queue<TreeNode> queue = new Queue<TreeNode>();
    //
    // first insert all the root nodes into the queue.
    //
    foreach(TreeNode root in tree.Nodes) {
        queue.Enqueue(root);
    }
    while(queue.Count > 0) {
        TreeNode node = queue.Dequeue();
        if(node != null) {
            //
            // Add the node to the list of nodes.
            //
            nodes.Add(node);
            if(node.Nodes != null && node.Nodes.Count > 0) {
                //
                // Enqueue the child nodes.
                //
                foreach(TreeNode child in node.Nodes) {
                    queue.Enqueue(child);
                }
            }
        }
    }

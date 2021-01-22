    private bool IsDestinationNodeAChildOfDraggingNode(TreeNode draggingNode, TreeNode destinationNode) {
    if (draggingNode.Nodes.Count == 0) 
            return false;
    else {
           if (draggingNode.Nodes.Contains(destinationNode)) 
                return true;
           else {
                foreach (TreeNode node in draggingNode.Nodes) 
                return IsDestinationNodeAChildOfDraggingNode(node, destinationNode);
                }
        }
    //Return something here.
    }

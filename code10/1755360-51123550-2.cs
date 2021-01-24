    namespace TreeNodeCollectionExtensions
    {
        public static class TncExtensions
        {
            public static int Add(this TreeNodeCollection nodes, DRT.DRT_TvwNode_Abstract myTreeViewNode)
            {
                int newNodeIndex = nodes.Add(myTreeViewNode);
    
                //Do stuff to custom properties that are members of DRT_TvwNode_Abstract and classes derived from DRT_TvwNode_Abstract
    
                return newNodeIndex;
            }
        }
    }
	

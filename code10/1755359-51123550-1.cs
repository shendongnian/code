	using TreeNodeCollectionExtensions;
	
    public class MyTreeView : MyTreeView_Abstract
    {
	    public MyTreeView() : base()
        {
        }
		
        public void CreateTree()
        {
            MyTreeViewNode myTreeViewNode;
			//Add node to root of TreeView
            myTreeViewNode = new MyTreeViewNode("root node text");
            Nodes.Add(Nodes, myTreeViewNode);
			
			//Add node one level below root node of TreeView
            myTreeViewNode = new MyTreeViewNode("level 1 node text");
            int newLevel1NodeIndex = Nodes.Add(Nodes[0].Nodes, myTreeViewNode);
			
			//Add node one level below level 1 node just created 
            myTreeViewNode = new MyTreeViewNode("level 2 node text");
            int newLevel2NodeIndex = Nodes.Add(Nodes[0].Nodes[newLevel1NodeIndex].Nodes, myTreeViewNode);
			
			//etc., etc.
		}
    }

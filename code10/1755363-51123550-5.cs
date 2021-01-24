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
            //Using named parameter to force the compiler to
            //use the Add extension method and not the base Add method
            myTreeViewNode = new MyTreeViewNode("root node text");
            Nodes.Add(myTreeViewNode: myTreeViewNode);
			
			//Add node one level below root node of TreeView
            //Using named parameter to force the compiler to
            //use the Add extension method and not the base Add method
            myTreeViewNode = new MyTreeViewNode("level 1 node text");
            int newLevel1NodeIndex = Nodes[0].Nodes.Add(myTreeViewNode: myTreeViewNode);
			
			//Add node one level below level 1 node just created 
            //Using named parameter to force the compiler to
            //use the Add extension method and not the base Add method
            myTreeViewNode = new MyTreeViewNode("level 2 node text");
            int newLevel2NodeIndex = Nodes[0].Nodes[newLevel1NodeIndex].Nodes.Add(myTreeViewNode: myTreeViewNode);
			
			//etc., etc.
		}
    }

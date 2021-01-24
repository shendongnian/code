    // all items are nodes
    abstract class Node {
    }
    // a tree is just a collection of nodes; it has no value
    class Tree: Node {
    	public Tree(params Node[] children) {
    		this.Children = children;
    	}
    	public Node[] Children { get; private set; }
    }
    // a leaf is just a value; it has no children
    class Leaf : Node {
    	public Leaf(int value) {
    		this.Value = value;
    	}
    	public int Value { get; private set; }
    }
    

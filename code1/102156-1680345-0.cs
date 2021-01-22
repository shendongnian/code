    using System;
    using System.Collections.Generic;
    using System.Linq;
    // WARNING : EXPERIMENTAL CODE : DO NOT USE FOR ANYTHING BUT EDUCATIONAL PURPOSES
    // comments about how crazy the code is : are welcome :)
    
    namespace stronglyTypedTree
    {
        // TreeNodes is a strongly typed List of strongly typed Nodes
        public class TreeNodes<T> : List<Node<T>>
        {
            // weird : sometimes the compiler informs me that new is
            // required, if i have not used new, and sometimes it informs
            // me, when I have added new, that new is not required
            public new void Add(Node<T> newNode)
            {
                Console.WriteLine("Add called in TreeNodes class : Type = " + typeof(T).ToString() + " : Node Key = " + newNode.Key.ToString());
                newNode.Parent = this;
                base.Add(newNode);
            }
        }
    
        // strongly typed Node
        public class Node<T>
        {
            // note : implement a key/value pair
            // instead of this ?
            internal T _key;
    
            // experimental : have not fully considered
            // the case of root nodes
    
            // better to make this a property ?
            public TreeNodes<T> Parent;
    
            // better to make this a property ?
            public TreeNodes<T> Nodes;
    
            public Node()
            {
                Nodes = new TreeNodes<T>();
            }
    
            // weird : calling base() here does NOT seem to call the
            // parameterless ctor above : the Nodes collection is, thus, 
            // not instantiated : will cause errors at run-time !
            public Node(T keyValue) : base()
            {
                _key = keyValue;
                // had to insert this : see note above
                Nodes = new TreeNodes<T>();
            }
    
            public T Key
            {
                get { return _key; }
                set { _key = value; }
            }
        }
    
        public class Tree<T>
        {
            public TreeNodes<T> Nodes;
    
            public string Name;
    
            public Tree()
            {
                Nodes = new TreeNodes<T>();
            }
    
            // weird : see note on ctor with one parameter
            // in the Node class above
            public Tree(string treeName) : base()
            {
                Name = treeName;
                // had to insert this : see note above
                Nodes = new TreeNodes<T>();
            }
        }
    
        // define some strongly typed Node classes
    
        // weird : i thought i could get away with not defining explicit ctors :
        // that ctor's of the Node class would be automatically invoked
        public class intNode : Node<int>
        {
            public intNode() : base() { }
    
            public intNode(int keyValue) : base(keyValue) { }
        }
    
        public class strNode : Node<string>
        {
            public strNode() : base() { }
    
            public strNode(string keyValue) : base(keyValue) { }
        }
    }

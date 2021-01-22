    class Node
    {
        protected string protectedName;
    }
    
    class NodeType1 : Node
    {
        public string Name
        {
            get
            {
                return protectedName;
            }
        }
    }
    
    class NodeType2 : NodeType1
    {
        protected void Foo()
        {
            string bar = Name;
        }
    }

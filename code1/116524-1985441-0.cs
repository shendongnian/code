    class Node
    {
        public string Name { get; set; }
    }
    class NodeType1 : Node
    {
        void SomeMethod()
        {
            string nm = base.Name;
        }
    }
    class NodeType2 : NodeType1
    {
        void AnotherMethod()
        {
            string nm = base.Name;
        }
    }

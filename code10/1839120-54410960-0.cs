    class node
    {
        public int value { get; }
        public int NodeLeft { get; }
        public int NodeRight { get; }
        public node(int value, int NodeLeft, int NodeRight)
        {
            this.value = value;
            this.NodeLeft = NodeLeft;
            this.NodeRight = NodeRight;
        }
    }

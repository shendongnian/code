    class NetNode
    {
        public string Text { get; set; }
        public List<NetNode> prevNodes { get; set; }
        public List<NetNode> nextNodes { get; set; }
        public float VX { get; set; }
        public float VY { get; set; }
        public string prevNodeNames;
        public NetNode(string text, string prevNodeNames)
        {
            this.prevNodeNames = prevNodeNames;
            prevNodes = new List<NetNode>();
            nextNodes = new List<NetNode>();
            Text = text; 
            VX = -1;
            VY = -1;
        }
        ...
    }

    public class Node 
    {
        public Node(string text)
        {
            this.Text = text;
            this.Head = this;
        }
        public Node(Node parent, string text): this(text)
        {
            if(parent!=null)
            {
                parent.Next = this;
                this.Head = parent.Head;
            }
        }
        public Node Head { get; }
        public Node Next { get; set; }
        public string Text { get; }
        public Node Add(string text) => new Node(this, text);
    }

    public class Node : IEnumerable<string>
    {
        public Node(string text)
        {
            this.Text = text;
            this.Head = this;
        }
        public Node(Node parent, string text) : this(text)
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
        public IEnumerator<string> GetEnumerator()
        {
            // Loop through the list, starting from head to end
            for(Node node = Head; node != null; node = node.Next)
            {
                yield return node.Text;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }

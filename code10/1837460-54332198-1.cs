    public class Node : IEnumerable<Node>
    {
       public Node(string text)
       {
            this.Text = text;
           this.Children = new List<Node>(); 
       }
       public string Text {get; private set;}
       public List<Node> Children { get; private set;} 
       public Node this[string childText]
       {
          get{ return this.Children.FirstOrDefault(x => x.Text == childText); }
       } 
        
       public void Add(string text, params Node[] childNodes)
       {
           var node = new Node(text);
           node.Children.AddRange(childNodes);
           this.Children.Add(node);
       }
        
        public IEnumerator<Node> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

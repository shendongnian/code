    public class Node
    {
       public Node(string text)
       {
            this.Text = text;
       }
       public string Text {get; private set;}
       public List<Node> Children { get; } = new List<Node>(); 
       public Node this[string childText]
       {
          get{ return this.Children.FirstOrDefault(x => x.Text = childText); }
       }  
    }

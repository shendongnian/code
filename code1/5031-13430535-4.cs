    public class GenericTree<T> where T : GenericTree<T> // recursive constraint  
    {
      // no specific data declaration  
  
      protected List<T> children;
  
      public GenericTree()
      {
        this.children = new List<T>();
      }
  
      public virtual void AddChild(T newChild)
      {
        this.children.Add(newChild);
      }
  
      public void Traverse(Action<int, T> visitor)
      {
        this.traverse(0, visitor);
      }
  
      protected virtual void traverse(int depth, Action<int, T> visitor)
      {
        visitor(depth, (T)this);
        foreach (T child in this.children)
          child.traverse(depth + 1, visitor);
      }
    }
      
    public class GenericTreeNext : GenericTree<GenericTreeNext> // concrete derivation
    {
      public string Name {get; set;} // user-data example
      
      public GenericTreeNext(string name)
      {
        this.Name = name;
      }
    }
    static void Main(string[] args)  
    {  
      GenericTreeNext tree = new GenericTreeNext("Main-Harry");  
      tree.AddChild(new GenericTreeNext("Main-Sub-Willy"));  
      GenericTreeNext inter = new GenericTreeNext("Main-Inter-Willy");  
      inter.AddChild(new GenericTreeNext("Inter-Sub-Tom"));  
      inter.AddChild(new GenericTreeNext("Inter-Sub-Magda"));  
      tree.AddChild(inter);  
      tree.AddChild(new GenericTreeNext("Main-Sub-Chantal"));  
      tree.Traverse(NodeWorker);  
    }  
    
    static void NodeWorker(int depth, GenericTreeNext node)  
    {                                // a little one-line string-concatenation (n-times)
      Console.WriteLine("{0}{1}: {2}", String.Join("   ", new string[depth + 1]), depth, node.Name);  
    }  

       public class Whatever
       {
          public Whatever Parent {get; private set;}
          protected List<Whatever> Children {get; private set;}
    
    
          public Whatever(Whatever parent)
          {
              this.parent = parent;
              this.Children = new List<Whatever>();
              if (parent != null)
              {
                  parent.Children.Add(this);
              }
          }
    
          public IEnumerable<Whatever> AllChildren
          {
             return this.Children.Union(this.Children.SelectMany(child => child.AllChildren));
          }

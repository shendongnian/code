    public class Category
    {
      public int Id {get; set;}
      public string Name {get; set; }
      private Category _Parent;
      public Category Parent {get { return _Parent; } 
       set {
         _Parent = value;
         _Parent.Children.Add(this);
       }
      }
      public List<Category> Children {get; private set; }
      public Category()
      {
        Children = new List<Category>();
      }
    }

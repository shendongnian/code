    public abstract class CategoryChild {
      private readonly int name;
      private Category c = null;
      public int Name { get { return name; } }
      public Category Parent { get { return c; } }
      public CategoryChild(int n, Category c) {
        this.name = n;
        AssignCategory(c);
      }
      public void AssignCategory(Category c) {
        if (c != null) {
          this.c = c;
          c.AddChild(this);
        }
      }
      public abstract void Display();
      public int Depth {
        get {
          if (Parent == null)
            return 0;
          else
            return 1 + Parent.Depth;
        }
      }
    }

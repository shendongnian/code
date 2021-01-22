    public class Item : CategoryChild {
      public Item(int n, Category c) : base(n, c) {}
      public override void Display() {
        for (int i = 0; i < Depth; i++)
          Console.Write("  ");
        Console.WriteLine("- Item " + Name.ToString());
      }
    }
    public class Category : CategoryChild {
      List<CategoryChild> kids = new List<CategoryChild>();
      public Category(int n, Category c) : base(n, c) {}
      public void AddChild(CategoryChild child) {
        kids.Add(child);
      }
      public override void Display() {
        for (int i = 0; i < Depth; i++)
          Console.Write("  ");
        Console.WriteLine("- Category " + Name.ToString());
        foreach (var kid in kids)
          kid.Display();
      }
    }

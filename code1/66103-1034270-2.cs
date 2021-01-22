    public static void Main() {
      var cats = new[] {
        new Category(1, null),
        new Category(2, null),
        new Category(3, null),
        new Category(4, null),
        new Category(5, null),
      };
      cats[2].AssignCategory(cats[1]);
      var items = new[] {
        new Item(6, cats[4]),
        new Item(5, cats[3]),
        new Item(3, cats[2]), new Item(4, cats[2]),
        new Item(1, cats[0]), new Item(2, cats[0]),
      };
      foreach (var root in cats.Where(c => c.Parent == null)
                               .OrderBy(c => c.Name))
        root.Display();
    }

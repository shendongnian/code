    public static Category SortedCategory(Category cat)
    {
      // get the root
      var root = cat;
      while(root.Parent != null) root = root.Parent;
      return root.GetSorted();
    }
    private Category GetSorted()
    {
      var sortedChildren = new List<Category>(childCategories).ConvertAll(c => c.GetSorted());
      sortedChildren.Sort((c1, c2) => c1.CatName.CompareTo(c2.Catname));
      return new Category { CatName = root.CatName, 
                            Catid = root.CatId,
                            childCategories = sortedChildren; }
    }

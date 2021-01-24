    class Categories
    {
       public Categories Parent { get; set; }
       public long Id { get; set; }
       public long ParentId { get; set; }
       public string Name { get; set; }
       public bool IsActive { get; set; }
       public List<Categories> ChildrenData { get; set; }
    }

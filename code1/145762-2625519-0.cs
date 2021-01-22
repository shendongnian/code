    public class MyItemsViewModel
    {
      public IList<MyGroupViewModel> Groups { get; }
    }
    
    public class MyGroupViewModel
    {
      public string GroupName { get; }
      public IList<MyItem> DistinctItems { get; }
    }

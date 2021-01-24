    public sealed class TableViewModel 
    {
      public int MyId { get; set; }
      public IEnumerable<SelectListItem> Items { get; set; }
      public string SomeField { get; set; }
      public string AnotherField { get; set; }
    }

    class SimpleClass
    {
      public int A { get; set; }
      public int B { get; set; }
      public int C { get; set; }
    }
    
    List<SimpleClass> Calc(IEnumerable<SimpleClass> list)
    {
      foreach(SimpleClass item in list)
      {
         item.C = item.A * item.C:
      }
      return list.ToList();
    }

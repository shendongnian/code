    class A
    {
        public string Foo   { get; set; }
        public string Bar   { get; set; }
        public bool HasDupe { get; set; }
    }
    
    var list = new List<A> 
              { 
                  new A{ Foo="abc", Bar="xyz"}, 
                  new A{ Foo="def", Bar="ghi"}, 
                  new A{ Foo="123", Bar="abc"}  
              };
     
    var dupes = list.Where(a => list
              .Except(new List<A>{a})
              .Any(x => x.Foo == a.Foo || x.Bar == a.Bar || x.Foo == a.Bar || x.Bar == a.Foo))
              .ToList();
    
    dupes.ForEach(a => a.HasDupe = true);

    class Sector {
      public int Id {set; get;}
      public string Name {set; get;}
    }
    
    ArrayList arrSectors = new ArrayList();
    arrSectors.Add(new Sector() {Id = 1, Name = "MySectorName"});
    arrSectors.Add(new Sector() {Id = 2, Name = "Foo"});
    arrSectors.Add(new Sector() {Id = 3, Name = "Bar"});

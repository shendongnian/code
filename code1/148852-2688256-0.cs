    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bar> Bars { get; set; }
    }
    
    class Bar
    {
        public string Color { get; set; }
    }
...
    List<Foo> foos = new List<Foo>()
    {
        new Foo() { Id = 1, Name = "Apple", Bars = new List<Bar> () { new Bar() { Color = "Red"}, new Bar() { Color="Green"}} },
        new Foo() { Id = 2, Name = "Orange", Bars = new List<Bar> () { new Bar() { Color = "Orange"},new Bar() { Color="Red Orange"}} },
        new Foo() { Id = 3, Name = "Banana",Bars = new List<Bar> () { new Bar() { Color = "Yellow"},new Bar() { Color="Green"}} },
        new Foo() { Id = 4, Name = "Pear",Bars = new List<Bar> () { new Bar() { Color = "Green"},new Bar() { Color="Yellow"}} }
    };
    
    string fooSearchName = "Apple";
    string barSearchColor = "Green";
    
    string fooSearchClause = "1 = 1";
    string barSearchClause = "1 = 1";
    
                
    if (!string.IsNullOrEmpty(fooSearchName))
    {
        fooSearchClause = string.Format("Name = \"{0}\"", fooSearchName);
    }
    
    if (!string.IsNullOrEmpty(barSearchColor))
    {
        barSearchClause = string.Format("Color = \"{0}\"", barSearchColor);
    }
    
    var query = foos.AsQueryable().Where(fooSearchClause).SelectMany(f => f.Bars).Where(barSearchClause);

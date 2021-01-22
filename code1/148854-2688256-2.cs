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
    
    string fooName = "Apple";
    string barColor = "Green";
    
    var fooQuery = foos.AsQueryable();
    
    if (!string.IsNullOrEmpty(fooName))
    {
        string filter = string.Format("Name = \"{0}\"", fooName);
        fooQuery = fooQuery.Where(filter);
    }
    
    var barQuery = fooQuery.SelectMany(f => f.Bars);
    
    if (!string.IsNullOrEmpty(barColor))
    {
        string filter = string.Format("Color = \"{0}\"", barColor);
        barQuery = barQuery.Where(filter);
    }

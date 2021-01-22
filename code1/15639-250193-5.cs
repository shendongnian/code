    class XYZ 
    {
       public XYZ () { AllNames = new List<string>(); }
       private List<string> AllNames { get; set; }
       public void AddName ( string name ) { AllNames.Add(name); }
       public IEnumerable<string> Names { get { return AllNames.AsReadOnly(); } }
    }

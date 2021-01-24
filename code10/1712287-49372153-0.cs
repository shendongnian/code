    public class XMLVariable
    {
        public string Name {get; set;}
        public string Value { get; set; }
        //MVC needed this parameterless constructor to bind View to new ViewModel
        public XMLVariable()
        { }
        
        //This was getting called before adding the parameterless constructor and failing
        public XMLVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public void Main()
    {
        Object.name = "test"; //Can access the object's properties now...
    }
    Objec ob = new Objec();
    
    public void Object
    {
        get { return ob; }
        set { ob = value; }
    }
    class Objec
    {
        public string name {get; set;}
        public string value {get; set;}
    }

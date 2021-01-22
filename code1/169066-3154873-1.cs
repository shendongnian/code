    public void Main()
    {
        Object.name = "test"; //Can access the object's properties now...
    }
    Objec ob = new Objec();
    
    public Objec Object
    {
        get { return ob; }
        set { ob = value; }
    }
    public class Objec
    {
        public string name {get; set;}
        public string value {get; set;}
    }

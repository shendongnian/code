    IEnumerable<SomeClass> data = GetValues();
    //or: SomeClass[] data = GetValues();
    //...
    public class SomeClass 
    {
        public string Name {get;private set;}
        public string Value {get;private set;}
        //...
    }

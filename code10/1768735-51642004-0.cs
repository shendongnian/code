    public class Root {
       public AsDocument<Child> FirstBorn {get;set;}
       public AsDocument<Child> SecondBorn {get;set;}
    }
    
    public class Child {
       public List<AsDocument<Possession>> Possessions {get;set;}
    }
    
    public class Possession {
    
    }

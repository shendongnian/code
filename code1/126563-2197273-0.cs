    interface ISomeClass<T> {
      T ValueINeed { get; set; }
    }
    
    class SomeClass<T> : ISomeClass {
    
     T ValueINeed { get; set;}
    }
    
    class ClassThatHasListOfGenericObjects{
    
     List<ISomeClass> _l = new List<ISomeClass>();
    
     public AddToList<T>(T someClass) : where T : ISomeClass {
    
     _l.Add(someClass);
    
     }
    
     public SomeMethod(){
    
       foreach(ISomeClass i in _l){
    
       i.ValueINeed; //this will work now, since it's in the interface
    
       }
     }
    }

    class A 
    {
       public string Id{get;set;}
       public string Name{get;set;}
       public string Order{get;set;}
       //this is the tricky one.
       public string ParentId{get;set;}
    }
    class B 
    {
       public string Id{get;set;}
       public string Name{get;set;}
       public string Order{get;set;}
       public A ClassA{get;set;}
    }
    class C 
    {
       public string Id{get;set;}
       public string Name{get;set;}
       public string Order{get;set;}
       public B ClassB{get;set;}
    }

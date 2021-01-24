    public class A
    {
         public B Countries {get;set;}
         public C Departments {get;set;}
    }
    
    public class B
    {
         public int Id {get;set;}
         public D Data {get;set;}
    }
    
    ...
    
    var result = JsonConvert.DeserializeObject<A>(json);

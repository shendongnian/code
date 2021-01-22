    public class Foo
    {
       public string A {get;set;}
       
       [Special]
       public string B {get;set;}   
    }
    
    var type = typeof(Foo);
    
    var specialProperties = type.GetRuntimeProperties()
    	 .Where(pi => pi.PropertyType == typeof (string) 
          && pi.GetCustomAttributes<Special>(true).Any());

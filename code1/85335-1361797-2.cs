    [ComVisible(true)]
    public class VBScriptObjects{
          public string Property1 {get;set;}
          public string Property2 {get;set;}
    }
    
    
    VBScriptObjects obj = new VBScriptObjects();
    
    sc.AddObject( "myObj", obj , false);
    sc.Run("myObj.Property1 = 'Testing'");
    
    obj.Property1 <-- this should have a new value now..

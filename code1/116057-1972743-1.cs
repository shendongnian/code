    public class Article
    {
    
     public object AddOrUpdate(params object[] paras){
    
       return null;
    
      }
    
    }
    
    public class Test:Article
    {
    
     public new object AddOrUpdate(params object[] paras){
    
       //do your logic......
    
        return base.AddOrUpdate(paras);
    
     }
    
    
    }

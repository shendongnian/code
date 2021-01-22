    public abstract class QueryParams
    {
      pubic string GetQueryString()
      {
        //use reflection here 
      }
    }
    
    public class MyQueryParams : QueryParams
    {
       public QueryParam MyParam1
       {
        get
         {
              if (_myParam1==null)
              { 
                 _myParam1=new QueryParam("MyParam1");
               }
               return _myParam1;
          }
    }
    public class QueryParam 
    {
       public string Name;
       public string Value;
    }

    public class DataContractFoo :IFoo, IDisposable
    {
           private static IList<News> news;
      public DataContractFoo()
      {
        //Load up news from a serialized news list from some xml file.
        
      }
           public IList<News> GetNews()
           {
              return news;
           }
       public void Dispose()
       {
          //Serialize news via the data contract serializer to your drive.
      
       }  
    }

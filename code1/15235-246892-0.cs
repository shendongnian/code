    using System;
    using System.Web.Services;
    
    [WebService(Namespace="http://www.contoso.com/")]
    public class MyService : WebService {
      public RemoteService remoteService;
      public MyService() {
         // Create a new instance of proxy class for 
         // the XML Web service to be called.
         remoteService = new RemoteService();
      }
      // Define the Begin method.
      [WebMethod]
      public IAsyncResult BeginGetAuthorRoyalties(String Author,
                      AsyncCallback callback, object asyncState) {
         // Begin asynchronous communictation with a different XML Web
         // service.
         return remoteService.BeginReturnedStronglyTypedDS(Author,
                             callback,asyncState);
      }
      // Define the End method.
      [WebMethod]
      public AuthorRoyalties EndGetAuthorRoyalties(IAsyncResult
                                       asyncResult) {
       // Return the asynchronous result from the other XML Web service.
       return remoteService.EndReturnedStronglyTypedDS(asyncResult);
      }
    }

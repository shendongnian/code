    public interface IServiceResponse { ... }
    public class ApplianceInitResp : IServiceResponse { ... }
    public interface IServiceRequest { ... }
    public class ApplianceInitReq : IServiceRequest { ... }
      
    public delegate IServiceResponse RestfulServiceRequest( IServiceRequest req );
      
    static class RestfulService
    {
        public static IServiceResponse
            Invoke( RestfulServiceRequest serviceCall, IServiceRequest req)        
        {
            if (req == null)
                throw new BadRequestException( ...inner-exception... );
             try
             {
                return serviceCall(req);
             }
             catch (RestfulException e)
             {
                Logger.Write(e);
                throw;               
             }
             catch (Exception e)
             {
                 Logger.Error(e);
                 throw new InternalServerException(e);
             }
             finally
             {
                 Logger.Debug("Complete");
             }
        }
    }
    public class Initialization : IInitialization
    {
         // MyMethod thas uses the template 
         public ApplianceInitResp CreateApplianceServer(ApplianceInitReq req) 
         {
              return RestfulService.Invoke(
                        delegate(ApplianceInitReq x)
                        {
                            // do some work
                            return new ApplianceInitResp();
                        },
                        req );
         }
    }

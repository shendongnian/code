    public class ExternalDataService : IExternalDataService
    {
       public IEnumerable<SomeDto> Getdata()
       {
            // consume the API (dll) here...
       }
    
       public SomeDto Getdata(object id)
       {
            // consume the API (dll) here...
       }
    }

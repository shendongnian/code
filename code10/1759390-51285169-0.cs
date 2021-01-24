    var provider = IProviderExtracter.Extract();
    
    public interface IProviderExtracter
    {
        Task<provider> Extract();
    }
    
    public class RequestProviderExtracter:IProviderExtracter
    {
        public Task<provider> Extract()
        { 
          return Request.Content.ReadAsMultipartAsync();
        }
    }

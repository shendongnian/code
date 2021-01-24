    public interface ICallResult { }
    public class CallSuccessful : ICallResult { }
    public class CallFail : ICallResult 
    {
       public string Details { get; set; }
    }
    public async Task<ICallResult> GetAsync(TResourceIdentifier identifier)

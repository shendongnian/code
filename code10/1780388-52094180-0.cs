    public interface IProvider
    {
        Task<string> ValidateAsync();
     
        ProviderType Type { get; }
    }

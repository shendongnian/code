    public interface IIdentityManager
    {
        //User manager methods
        Task<IIdentityResult> CreateAsync(IApplicationUser user);
        //..all methods needed
    }
    public interface IIdentityResult
    {
        bool Succeeded { get; set; }
        List<string> Errors { get; set; }
    }

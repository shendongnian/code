    public interface IOneTimeOnlyJwtTokenService
    {
        Task<string> BuildToken(string name, int? expires);
        Task<bool> HasBeenConsumed(string token);
        Task InvalidateToken(string token);
    }

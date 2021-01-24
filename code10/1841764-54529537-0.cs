    public abstract class Result
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
    }
    public class SignInResult : Result
    {
        public SignInResponse Response { get; set; }
    }
    public class ListResult : Result
    {
        public IList<ListResponse> Response { get; set; }
    }

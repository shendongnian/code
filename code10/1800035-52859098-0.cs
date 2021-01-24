    [DataContract]
    public class Response
    {
        [DataMember(Name = "error_code")]
        public int ErrorCode { get; set; }
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }
    }

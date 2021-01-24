    public class AuthenticationResponse
        {
            [DeserializeAs(Name = "jsonrpc")]
            public String Jsonrpc {get;set;}
            [DeserializeAs(Name = "id")]
            public int Id { get; set; }
            [DeserializeAs(Name = "result")]
            AuthenticationResult Result { get; set; }
        }

    public class AuthenticationResponse
        {
            [DeserializeAs(Name = "id")]
            public string id { get; set; }
            [DeserializeAs(Name = "result")]
            AuthenticationResult res { get; set; }
            
            public string jsonrpc { get; set; } // Can remove if you dont need it.
        }

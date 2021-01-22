    [JsonRpcService("Service")]
    public class Service : JsonRpcHandler
    {
        [JsonRpcMethod("call", Idempotent = true)]
        public string call(string value)
        {
            JsonObject oJSON = JsonConvert.Import(typeof(JsonObject), value) as JsonObject;
           ...
           return oJSON.ToString();
        }
    }
}

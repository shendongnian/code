    using Jayrock;
    using Jayrock.JsonRpc;
    using Jayrock.JsonRpc.Web;
    using Jayrock.Json;
    using Jayrock.Json.Conversion;
    
    
    namespace myRPCService
    {
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

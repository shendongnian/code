    class Program {
        private static readonly WebSocket _webSocket = new WebSocket("wss://ws-feed.gdax.com");
        private static long _lastSequence = 0;
        private static readonly HashSet<string> _expectedTypes = new HashSet<string>(
            new[] { "received", "open", "done", "match", "change", "activate" });
        static void Main(string[] args) {
            var subMsg = "{\"type\": \"subscribe\",\"product_ids\": [\"ETH-USD\"],\"channels\": [\"full\"]}";
            _webSocket.OnMessage += WebSocket_OnMessage;
            _webSocket.Connect();
            _webSocket.Send(subMsg);
            Console.ReadKey();
        }        
        private static void WebSocket_OnMessage(object sender, MessageEventArgs e) {
            var message = JsonConvert.DeserializeObject<BaseMessage>(e.Data);
            if (_expectedTypes.Contains(message.Type)) {
                lock (typeof(Program)) {
                    if (_lastSequence == 0)
                        _lastSequence = message.Sequence;
                    else {
                        if (message.Sequence > _lastSequence + 1) {
                            Debugger.Break(); // never hits, so nothing is dropped
                        }
                        _lastSequence = message.Sequence;
                    }
                }
            }
        }
    }
    public class BaseMessage {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
        [JsonProperty("sequence")]
        public long Sequence { get; set; }
    }

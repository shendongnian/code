      public class Payload
        {
            public int PayloadId { get; set; }
            public Guid Nonce { get; set; }
            public string Timestamp { get; set; }
            public string WebhookId { get; set; }
            public string Scope { get; set; }
    
            public string ScopeObjectId { get; set; }
            public virtual List<PayloadEvent> Events { get; set; }
        }
    
        public class PayloadEvent
        {
            public int PayloadEventId { get; set; }
            public string ObjectType { get; set; }
            public string EventType { get; set; }
    
            [JsonProperty(PropertyName = "Id")]
            public string EventId { get; set; }
    
            public string UserId { get; set; }
    
            public string Timestamp { get; set; }
        }

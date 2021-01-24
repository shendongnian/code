    public class MessageEntity : TableEntity
    {
        public MessageEntity(string pk, string rk)
        {
            this.PartitionKey = pk;
            this.RowKey = rk;
        }
    
        public MessageEntity() { }
    
        public string BotId { get; set; }
        public string ChannelId { get; set; }
        public string ConversationId { get; set; }
        public byte[] Data { get; set; }
        public string UserId { get; set; }
    }

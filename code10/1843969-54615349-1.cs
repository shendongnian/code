    public class ChatInfoModel
    {
        [JsonProperty(Metadata.ChatId)]
        public long ChatId { get; set; }
        [JsonProperty(Metadata.ChatId, Required = Required.AllowNull)]
        public String Message { get; set; }
    }
    public struct Metadata
    {
        public const String ChatId = "userChatId"; 
        public const String Message = "messageTxt"l
    }

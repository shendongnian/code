    public partial class MailRoomList<T> {
        [JsonProperty("GetListItemsResult")]
        public GetListItemsResult<T> GetListItemsResult { get; set; }
    }
    public class GetListItemsResult<T> {
        [JsonProperty("Data")]
        public T[] Data { get; set; }
        [JsonProperty("ErrorDetail")]
        public ErrorDetail ErrorDetail { get; set; }
    
        [JsonProperty("Result")]
        public bool Result { get; set; }
    }

    public class BaseResponse<TD, TR>
    {
        public Session session { get; set; }
        public int httpStatus { get; set; }
        public TR Response { get; set; }
        public TD Data {get; set;}
    }
    var response = JsonConverter.Deserialize<BaseResponse<Data, ResponseA>>(json);

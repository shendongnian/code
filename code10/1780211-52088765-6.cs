    public class BaseResponseObject {
        public bool success { get; set; }
    }
    public class ClassResponseObject : BaseResponseObject {
        public int row_index { get; set; }
        public string message { get; set; };
    }
    public class UserResponseObject : BaseResponseObject {
        public int user_id { get; set; }
        public MessageResponseObject message { get; set; };
    }

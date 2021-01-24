    public class ClassResponseObject : BaseResponseObject<String> {
        public int row_index {get; set;}
    }
    public class UserResponseObject : BaseResponseObject<MessageResponseObject> {
        public int user_id {get; set;}
    }

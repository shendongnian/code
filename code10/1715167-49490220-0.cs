    public class UserRequest
    {
        public String userName { get; set; }
        public String password { get; set; }
        public String userId { get; set; }
    }
    public class UserRequest<T> : UserRequest
        where T : RealmObject
    {
        public int page { get; set; }
        public IList<T> requestList { get; set; }
    }

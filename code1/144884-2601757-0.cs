    [DataContract]
    public class User
    {
        [DataMember] public string id{ get; set; }
        [DataMember] public string name{ get; set; }
        [DataMember] public string password { get; set; }
        [DataMember] public string email { get; set; }
        [DataMember] public bool is_broker { get; set; }
        [DataMember] public string branch_id { get; set; }
        [DataMember] public string created_at{get; set;}
        [DataMember] public string updated_at{get; set;}
        public UserGroup UserGroup {get;set;}
        public UserAddress UserAddress { get; set; }
        public List<UserContact> UserContact {get; set;}
    
        public User()
        {
            UserGroup = new UserGroup();
            UserAddress = new UserAddress();
            UserContact = new List<UserContact>();
        }
    }

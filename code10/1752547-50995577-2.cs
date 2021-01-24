    class UserServiceData
    {
        public string Name { get; set; }
        public int SomeDate { get; set; }
        public int SomeData1 { get; set; }
    }
    
    class B
    {
        public static IDictionary<UserServiceData, IClientKdcCallBack> users_list = new Dictionary<UserServiceData, IClientKdcCallBack>();
    
        public bool isUserExists(string userName)
        {
            return users_list.Keys.Any(x => x.Name.Equals(userName));
        }
    }

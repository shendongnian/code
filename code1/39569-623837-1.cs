    interface IUser
    {
        string UserName
        {
            get;
        }
    }
    interface IMutableUser
    {
        string UserName
        {
            get;
            set;
        }
    }
    class User : IUser, IMutableUser
    {
        public string UserName { get; set; }
    }

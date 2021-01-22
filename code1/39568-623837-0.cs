    interface IUser
    {
        string UserName
        {
            get;
        }
    }
    
    abstract class MutableUser : IUser
    {
        public virtual string UserName
        {
            get;
            set;
        }
    }

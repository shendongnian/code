    public class MyWCFClass : IMyWCFClass
    {
        private readonly IUserDAL _userDAL;
    
        public MyWCFClass()
            : this(new DefaultUserDAL())
        {
        }
    
        public MyWCFClass(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
    }

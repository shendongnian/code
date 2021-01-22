    public class MyWCFClass: IMyWCFClass
    {
        private Type _myUserDALType;
        public MyWCFClass()
        {
            _myUserDALType = typeof(UserDAL);
        }
        public MyWCFClass(Type myUserDALType)
        {
            _myUserDALType = myUserDALType;
        }
    
        //methods to use it
        public void MyMethod()
        {
            IUserDAL userDAL = (IUserDAL) Activator.CreateInstance(_myUserDALType );
            //Call method in IUserDAL
            userDAL.CreateUser();
        }
    }

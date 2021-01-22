    public abstract class MyServiceImpl
    {
        public void MyMethod(string entityId)
        {
            CheckPermissions(entityId);
            //move along...
        }
        protected abstract bool CheckPermissions(string entityId);
    }
    public class MyServiceUnitTest
    {
        private bool CheckPermissions(string entityId)
        {
            return true;
        }
    }
    public class MyServiceMyAuth
    {
        private bool CheckPermissions(string entityId)
        {
            //do some custom authentication
            return true;
        }
    }

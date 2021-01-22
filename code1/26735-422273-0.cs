    [ServiceContract]
    public interface IYourBusinessService
    {
        [OperationContract]
        void DoWork();
    }
    public class YourBusinessService : IYourBusinessService
    {
        public void DoWork()
        {
            //do some business logic here
        }
    }

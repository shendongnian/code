    public interface IAccountRemovalService<T>
    {
        void RemoveAccount<T>(T model);
    }
    public class ServiceA : IAccountRemovalService<ServiceA_AccountDataModel>
    {
        public void RemoveAccount<ServiceA_AccountDataModel>(ServiceA_AccountDataModel model) 
        { 
        }
    }
    public class ServiceB : IAccountRemovalService<ServiceB_AccountDataModel>
    {
        public void RemoveAccount<ServiceB_AccountDataModel>(ServiceA_AccountDataModel model) 
        { 
        }
    }

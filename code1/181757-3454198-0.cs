    [ServiceContract]
    public interface ISemaphorService
    {
        [OperationContract]
        void Acquire();
        [OperationContract]    
        void Release();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SemaphoreService
    {
        private readonly static Semaphore Pool = new Semaphore(5, 5);
        public void Acquire()
        {
           Pool.WaitOne();
        }
        public void Release()
        {
           Pool.Release();
        }
    }

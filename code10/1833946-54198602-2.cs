    namespace MyService
    {
        [ServiceContract]
        public interface IMyService : IUSer, IDevice
        {
            [OperationContract]
            string GetName();
            [OperationContract]
            bool SetName(string name);
            [OperationContract]
            string GetDeviceName();
            [OperationContract]
            bool SetDeviceName(string name);
        }
        public interface IUSer
        {
            string GetName();
            bool SetName(string name);
        }
        public interface IDevice
        {
            string GetDeviceName();
            bool SetDeviceName(string name);
        }
    }

    namespace MyService
    {
        [ServiceContract]
        public interface IUSer
        {
            [OperationContract]
            string GetName();
            [OperationContract]
            bool SetName(string name);
        }
        [ServiceContract]
        public interface IDevice
        {
            [OperationContract]
            string GetDeviceName();
            [OperationContract]
            bool SetDeviceName(string name);
        }
    }

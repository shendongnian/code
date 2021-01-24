    [ServiceContract]
    public interface IService
    {
        // not exposed 
        byte[] TaskResults { get; set; }
        
        [OperationContract]
        byte[] GetData();
    }
    public class Service : IService
    {
        public byte[] TaskResults { get; set; }
        public byte[] GetData()
        {
            //byte[] result = new byte[5000];
            //return result;
            return TaskResults;
        }
    }

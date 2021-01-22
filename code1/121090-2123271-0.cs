    [ServiceContract(CallbackContract = typeof(IClient), SessionMode = SessionMode.Required)]
    public interface IServer
    {
        [OperationContract]
        FilePart GetFileChunk(string identifier, int number, int blockSize);   
    }

    public class OCRService : IOCRService, IDisposable
    {
        public OCRService(IComputerVisionClient client)
        {
            _client = client;
        }
    }

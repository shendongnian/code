    [ServiceContract]
    public interface IDaraWriterService
    {
         [OperationContract]
         public void WriteDataToQueue(WriteDataToQueueMessage theDataEncapsulatedInAMessage)
         {
         }
    }

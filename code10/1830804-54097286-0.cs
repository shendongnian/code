    [QueueTrigger("myQueueName", Connection = "mySTORAGE")] POCO item,
    [Blob("outbound/{blobName}", FileAccess.Write, Connection = Settings.InbundBlobConnectionString)] Stream outboundBlob
       …
    public class POCO
    {
      // ...
      public string blobName { get; set;}
    }

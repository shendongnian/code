    public static void Run(DataPoint myIoTHubMessage, out OutPutData outputTable, TraceWriter log)
    {
       log.Info($"C# IoT Hub trigger function processed a message: {myIoTHubMessage}");
        outputTable = new OutPutData
        {
            PartitionKey = myIoTHubMessage.cameraName,
            RowKey = myIoTHubMessage.dateTime,
            Area = myIoTHubMessage.area
        };
    }
    public class DataPoint : TableEntity
    {
       public string cameraName { get; set; }
       public string dateTime { get; set; }
       public double Area { get; set; }
    }
    public class OutPutData : TableEntity
    {
       public double Area { get; set; }
    }

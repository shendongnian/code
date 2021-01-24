    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using Microsoft.Azure.EventHubs;
    using System.Text;    
    
    public static class EventHubFunctions
        {
            [FunctionName("ProcessEventHubQueue")]
            public static void Run(
        [EventHubTrigger("my-iot-eventhub", ConsumerGroup = "consumergroup1", Connection = "EventHubConnectionString")]
        EventData[] eventHubMessages,
        ILogger log)
            {
                foreach (EventData myEventHubMessage in eventHubMessages)
                {
                   String messageBody = Encoding.UTF8.GetString(myEventHubMessage.Body);
                   log.LogInformation($"EventData MessageBody: {messageBody}");
    
                }
            }

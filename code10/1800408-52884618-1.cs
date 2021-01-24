    #r "Microsoft.Azure.EventHubs"
    
    using System;
    using Microsoft.Azure.EventHubs;
    
    public static void Run(EventData myEventHubMessage, ILogger log)
    {
        log.LogInformation($"EnqueuedTimeUtc={myEventHubMessage.SystemProperties.EnqueuedTimeUtc}");
        log.LogInformation($"SequenceNumber={myEventHubMessage.SystemProperties.SequenceNumber}");
        log.LogInformation($"Offset={myEventHubMessage.SystemProperties.Offset}");
    }

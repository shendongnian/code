    #r "Microsoft.Azure.DocumentDB.Core"
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Documents;
           
    public static void  Run(QueueItem myQueueItem, ILogger log, IEnumerable<dynamic> documents)
    {      
        foreach(var doc in documents)
        {
            log.LogInformation((string)doc.id);
        }
    }
    public class QueueItem
    {
        public string contractId { get; set; }
    }

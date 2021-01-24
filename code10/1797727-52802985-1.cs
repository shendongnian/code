        //Func1/Func1.cs
        using static MyNameSpace.Shared.Utils;
        using System;
        using Microsoft.Azure.WebJobs;
        using Microsoft.Azure.WebJobs.Host;
        using Microsoft.Extensions.Logging;
        namespace MyNameSpace
        {
            public static class Func1
            {
                [FunctionName("Func1")]
                public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
                {
                    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
                    int x = MyAdd(5, 7);
                    log.LogInformation($"Result: {x}");
                }
            }
        }
 

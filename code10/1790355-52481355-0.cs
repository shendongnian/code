        using System;
        public static void Run(string myIoTHubMessage, IDictionary<string, object> properties, IDictionary<string, object> systemproperties, TraceWriter log)
        {
           log.Info($"C# IoT Hub trigger function processed a message: \n\t{myIoTHubMessage}");
    
           log.Info($"\nSystemProperties:\n\t{string.Join("\n\t", systemproperties.Select(i => $"{i.Key}={i.Value}"))}");
           log.Info($"\nProperties:\n\t{string.Join("\n\t", properties.Select(i => $"{i.Key}={i.Value}"))}");
        }

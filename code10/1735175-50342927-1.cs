        #r "Microsoft.ServiceBus"
    
        using System.Configuration;
        using System.Text;
        using System.Net;
        using Microsoft.Azure.Devices;
        using Microsoft.ServiceBus.Messaging;
        using Newtonsoft.Json;
    
        static Microsoft.Azure.Devices.ServiceClient client =     ServiceClient.CreateFromConnectionString(ConfigurationManager.AppSettings["iothubConnectionstring"]);
    
        public static async void Run(EventData myIoTHubMessage, TraceWriter log)
        {
            log.Info($"{myIoTHubMessage.SystemProperties["iothub-connection-device-id"]}");
            var deviceId = myIoTHubMessage.SystemProperties["iothub-connection-device-id"].ToString();
            var msg = JsonConvert.SerializeObject(new { temp = 20.5 });
            var c2dmsg = new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes(msg));
    
            await client.SendAsync(deviceId, c2dmsg);
        }

SELECT COUNT() AS numberOfDevices FROM c
which returns something like this:
[
  {
    "numberOfDevices": 123
  }
]
To retrieve the **number of messages** you need to connect to the Event Hub-compatible endpoint, connecting to each underlying partition and looking at each *Partition Info* (*Last Sequence Number* and *Sequence Number*). There is some data retention involved though, so unless you add more logic to this, you will get a number representing the count of messages **currently** present in the hub, not the total since the creation, not the total left to process.
Update: here's the code showing a couple of methods to get the number of devices:
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices;
    using Newtonsoft.Json;
    namespace Test
    {
        class Program
        {
            static async Task Main()
            {
                string connString = "HostName=_______.azure-devices.net;SharedAccessKeyName=_______;SharedAccessKey=_______";
                RegistryManager registry = RegistryManager.CreateFromConnectionString(connString);
                // Method 1: using Device Twin
                string queryString = "SELECT COUNT() AS numberOfDevices FROM devices";
                IQuery query = registry.CreateQuery(queryString, 1);
                string json = (await query.GetNextAsJsonAsync()).FirstOrDefault();
                Dictionary<string, long> data = JsonConvert.DeserializeObject<Dictionary<string, long>>(json);
                long count1 = data["numberOfDevices"];
                // Method 2: using Device Registry
                RegistryStatistics stats = await registry.GetRegistryStatisticsAsync();
                long count2 = stats.TotalDeviceCount;
            }
        }
    }

    #r "Newtonsoft.Json"
    #r "Microsoft.ServiceBus"
    #r "System.Runtime.Serialization"
    using System.Text;
    using System.Runtime.Serialization;
    using System.Net;
    using Newtonsoft.Json;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IAsyncCollector<BrokeredMessage> collector, TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request.");
        // parse query parameter
        string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;
        if (name == null)
        {
            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();
            name = data?.name;
        }
        // brokered message
        var payload = JsonConvert.SerializeObject(new { id = 1234, name = "abcd" });
        var bm = new BrokeredMessage(new MemoryStream(Encoding.UTF8.GetBytes(payload)), true) { ContentType = "application/json", Label = "Hello", MessageId = "1234567890" };
        await collector.AddAsync(bm);
        return name == null
            ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
    }

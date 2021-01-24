    using System;
    using Google.Cloud.Dialogflow.V2;
    using Google.Protobuf.WellKnownTypes;
    
    class Program
    {
        static void Main(string[] args)
        {
            var googlePayload = new Struct
            {
                Fields = { { "expectUserPayload", Value.ForBool(false) } }
            };
            var response = new WebhookResponse
            {
                FulfillmentText = $"Your magic number is 100.",
                Payload = new Struct
                {
                    Fields = { { "google", Value.ForStruct(googlePayload) } }
                }
            };
    
            Console.WriteLine(response);
        }
    }

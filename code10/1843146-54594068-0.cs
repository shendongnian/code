    using Google.Cloud.Vision.V1;
    using System;
    using Grpc.Auth;
    using Google.Apis.Auth.OAuth2;
    
    namespace VisionDemo
    {
        class Program
        {   
            static void Main(string[] args)
            {
                //Authenticate to the service by using Service Account
                var credential = GoogleCredential.FromFile(@"<CREDENTIALS_JSON_FILE_PATH>").CreateScoped(ImageAnnotatorClient.DefaultScopes);
                var channel = new Grpc.Core.Channel(ImageAnnotatorClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
                // Instantiates a client
                var client = ImageAnnotatorClient.Create(channel);
                var image = Image.FromFile(@"<IMAGE_PATH>");
                var response = client.DetectLabels(image); // error
                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                        Console.WriteLine(annotation.Description);
                }
    
            }
        }
    }

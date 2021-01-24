    using System;
    using System.Net;
    using System.Collections.Specialized;
    using System.Text;
    using Newtonsoft.Json;
    
    public class SlackExample
    {
        // classes for converting JSON respones from API method into objects
        // note that only those properties are defind that are needed for this example
    
        // reponse from file methods
        class SlackFileResponse
        {
            public bool ok { get; set; }
            public String error { get; set; }
            public SlackFile file { get; set; }
        }
    
        // a slack file
        class SlackFile
        {
            public String id { get; set; }
            public String name { get; set; }        
        }
    
        // main method with logic
        public static void Main()
        {
            var parameters = new NameValueCollection();
    
            // put your token here
            parameters["token"] = "xoxp-YOUR-TOKEN";
            parameters["channels"] = "test";
    
            var client = new WebClient();
            client.QueryString = parameters;
            byte[] responseBytes = client.UploadFile(
                    "https://slack.com/api/files.upload",
                    "D:\\temp\\Stratios_down.jpg"
            );
    
            String responseString = Encoding.UTF8.GetString(responseBytes);
    
            SlackFileResponse fileResponse =
                JsonConvert.DeserializeObject<SlackFileResponse>(responseString);
        }
    }
    

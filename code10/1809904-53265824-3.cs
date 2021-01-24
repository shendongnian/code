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
            public String permalink_public { get; set; }
        }
    
        // reponse from message methods
        class SlackMessageResponse
        {
            public bool ok { get; set; }
            public String error { get; set; }
            public String channel { get; set; }
            public String ts { get; set; }        
        }
    
        // a slack message attachment
        class SlackAttachment
        {
            public String fallback { get; set; }
            public String text { get; set; }
            public String image_url { get; set; }
        }
    
        // main method with logic
        public static void Main()
        {
            String token = "xoxp-YOUR-TOKEN";
    
    
            /////////////////////
            // Step 1: Upload file to Slack
    
            var parameters = new NameValueCollection();
    
            // put your token here
            parameters["token"] = token;
            
            var client1 = new WebClient();
            client1.QueryString = parameters;
            byte[] responseBytes1 = client1.UploadFile(
                    "https://slack.com/api/files.upload",
                    "C:\\Temp\\Stratios_down.jpg"
            );
    
            String responseString1 = Encoding.UTF8.GetString(responseBytes1);
    
            SlackFileResponse fileResponse1 = 
                JsonConvert.DeserializeObject<SlackFileResponse>(responseString1);
    
            String fileId = fileResponse1.file.id;
    
    
            /////////////////////
            // Step 2: Make file public and get the URL
    
            var parameters2 = new NameValueCollection();
            parameters2["token"] = token;
            parameters2["file"] = fileId;
    
            var client2 = new WebClient();
            byte[] responseBytes2 = client2.UploadValues("https://slack.com/api/files.sharedPublicURL", "POST", parameters2);
    
            String responseString2 = Encoding.UTF8.GetString(responseBytes2);
    
            SlackFileResponse fileResponse2 =
                JsonConvert.DeserializeObject<SlackFileResponse>(responseString2);
    
            String imageUrl = fileResponse2.file.permalink_public;
    
    
            /////////////////////
            // Step 3: Send message including freshly uploaded image as attachment
    
            var parameters3 = new NameValueCollection();
            parameters3["token"] = token;
            parameters3["channel"] = "test_new";        
            parameters3["text"] = "test message 2";
    
            // create attachment
            SlackAttachment attachment = new SlackAttachment();
            attachment.fallback = "this did not work";
            attachment.text = "this is anattachment";
            attachment.image_url = imageUrl;
            SlackAttachment[] attachments = { attachment };        
            parameters3["attachments"] = JsonConvert.SerializeObject(attachments);
    
            var client3 = new WebClient();
            byte[] responseBytes3 = client3.UploadValues("https://slack.com/api/chat.postMessage", "POST", parameters3);
    
            String responseString3 = Encoding.UTF8.GetString(responseBytes3);
    
            SlackMessageResponse messageResponse =
                JsonConvert.DeserializeObject<SlackMessageResponse>(responseString3);
            
        }
    }

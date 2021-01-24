    using System;
    using System.Net;
    using System.Collections.Specialized;
    using System.Text;
    
    public class SlackExample
    {    
        public static void SendMessageToSlack()
        {        
            var data = new NameValueCollection();
            data["token"] = "xoxp-YOUR-TOKEN";
            data["channel"] = "blueberry";        
            data["as_user"] = "true";           // to send this message as the user who owns the token, false by default
            data["text"] = "test message 2";
            data["attachments"] = "[{\"fallback\":\"dummy\", \"text\":\"this is an attachment\"}]";
    
            var client = new WebClient();
            var response = client.UploadValues("https://slack.com/api/chat.postMessage", "POST", data);
            string responseInString = Encoding.UTF8.GetString(response);
            Console.WriteLine(responseInString);        
        }
    
        public static void Main()
        {
            SendMessageToSlack();
        }
    }

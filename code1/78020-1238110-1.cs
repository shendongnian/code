     public class WebClientEx : WebClient
     {
         public int Timeout {get; set;}
         protected override WebRequest GetWebRequest(Uri address)
         {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
         }
     }

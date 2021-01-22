    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class WebGui : IWebGui
    {
        public Stream GetGrid()
        {
            string output = "test";
                      
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(output));
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return ms;
        }
    }

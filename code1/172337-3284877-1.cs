    public class ServiceType : IService
    {
        public Stream Get(string arguments)
        {
            UriTemplateMatch uriInfo = WebOperationContext.Current.IncomingRequest.UriTemplateMatch;
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            
            MemoryStream rawResponse = new MemoryStream();
            TextWriter response = new StreamWriter(rawResponse, Encoding.UTF8);
            response.Write("<html><head><title>Hello</title></head><body>");
            response.Write("<b>Path</b>: {0}<br/>", arguments);
            response.Write("<b>RequestUri</b>: {0}<br/>", uriInfo.RequestUri);
            response.Write("<b>QueryParameters</b>: {0}<br/>", uriInfo.QueryParameters.ToString());
            response.Write("</body></html>");
            response.Flush();
            rawResponse.Position = 0;
            return rawResponse;
        }
    }

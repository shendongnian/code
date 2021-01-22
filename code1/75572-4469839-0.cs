    public class UriInspector: IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // change/replace request.Headers.To Uri object;
            return null;
        }
    }

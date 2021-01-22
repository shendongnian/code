        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request,  System.ServiceModel.IClientChannel channel)
    {
        HttpRequestMessageProperty httpRequestMessage;
        object httpRequestMessageObject;
        if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
        {
            httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
            if (string.IsNullOrEmpty(httpRequestMessage.Headers[USER_AGENT_HTTP_HEADER]))
            {
                httpRequestMessage.Headers[USER_AGENT_HTTP_HEADER] = this.m_userAgent;
            }
        }
        else
        {
            httpRequestMessage = new HttpRequestMessageProperty();
            httpRequestMessage.Headers.Add(USER_AGENT_HTTP_HEADER, this.m_userAgent);
            request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
        }
        return null;
    }

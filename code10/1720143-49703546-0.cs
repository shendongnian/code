    string auth = @"<DocuSignCredentials>
                       <Username>john.connolly@lechase.com</Username>
                       <Password>S3cre+p455w0Rd</Password>
                       <IntegratorKey>20be051c-4c25-46c1-b0f1-1f10575a2e40</IntegratorKey>
                    </DocuSignCredentials>";
    
    DSAPIServiceSoapClient apiService = new DSAPIServiceSoapClient();            
    
    using (var scope = new System.ServiceModel.OperationContextScope(apiService.InnerChannel))
    {
        var httpRequestProperty = new System.ServiceModel.Channels.HttpRequestMessageProperty();
        httpRequestProperty.Headers.Add("X-DocuSign-Authentication", auth);
        System.ServiceModel.OperationContext.Current.OutgoingMessageProperties[System.ServiceModel.Channels.HttpRequestMessageProperty.Name] = httpRequestProperty;
    
        EnvelopeStatus envStatus = apiService.CreateAndSendEnvelope(envelope);
        return envStatus.EnvelopeID;
    }

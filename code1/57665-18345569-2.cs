    var service = new BarServiceClient();
    service.ClientCredentials.ClientCertificate.Certificate = MessageSigningCertificate;
    using (new OperationContextScope(service.InnerChannel))
    {
        OperationContext.Current.OutgoingMessageHeaders.Add(
          new UserNamePasswordHeader(serviceUserEmail, serviceUserPassword));
        try
        {
            var response = service.GetUserList();
            return response;
        }
        finally
        {
            service.Close();
        }
    }

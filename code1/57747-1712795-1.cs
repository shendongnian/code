      using (OperationContextScope scope = new OperationContextScope(RefundClient.InnerChannel))
      {
                var httpRequestProperty = new HttpRequestMessageProperty();
                httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
                Convert.ToBase64String(Encoding.ASCII.GetBytes(RefundClient.ClientCredentials.UserName.UserName + ":" +
                RefundClient.ClientCredentials.UserName.Password));
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
    
                PaymentResponse = RefundClient.Payment(PaymentRequest);
       }

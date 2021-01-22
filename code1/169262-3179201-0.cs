    static void RunService()
        {
          //Step1: Create a custom binding with just TCP.
          BindingElement[] bindingElements = new BindingElement[2];
          bindingElements[0] = new WebMessageEncodingBindingElement();
          bindingElements[1] = new HttpTransportBindingElement();
    
          CustomBinding binding = new CustomBinding(bindingElements);
    
    
          //Step2: Use the binding to build the channel listener.     
          IChannelListener<IReplyChannel> listener =
             binding.BuildChannelListener<IReplyChannel>(new Uri("http://localhost:8080/channelapp"),
              new BindingParameterCollection());
    
          //Step3: Listening for messages.
          listener.Open();
          Console.WriteLine(
              "Listening for incoming channel connections");
      
          //Wait for and accept incoming connections.
          IReplyChannel channel = listener.AcceptChannel();
          Console.WriteLine("Channel accepted. Listening for messages");
      
          //Open the accepted channel.
          channel.Open();
      
          //Wait for and receive a message from the channel.
          RequestContext request= channel.ReceiveRequest();
      
          //Step4: Reading the request message.
          Message message = request.RequestMessage;
          Console.WriteLine("Message received");
          Console.WriteLine("To: {0}", message.Headers.To); // TO contains URL from the browser including query string  
          if (!message.IsEmpty) // HTTP GET does not contain body
          {
            string data = message.GetBody<string>();
            Console.WriteLine("Message content: {0}", data);
          }
    
          //Send a reply - You can control reply content based on message.Header.To or by message content
          Message replymessage = Message.CreateMessage(binding.MessageVersion, 
            "http://contoso.com/someotheraction", XElement.Parse("<html><body><h1>Hello</h1></body></html>"));
    
          // Set reply content type
          HttpResponseMessageProperty property = new HttpResponseMessageProperty();
          property.Headers[System.Net.HttpResponseHeader.ContentType] = "text/html; charset=utf-8";
          replymessage.Properties[HttpResponseMessageProperty.Name] = property;
    
          request.Reply(replymessage);
    
          //Step5: Closing objects.
          //Do not forget to close the message.
          message.Close();
          //Do not forget to close RequestContext.
          request.Close();
          //Do not forget to close channels.
          channel.Close();
          //Do not forget to close listeners.
          listener.Close();
        }

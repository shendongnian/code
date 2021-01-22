    public class MySoapExtension: SoapExtension 
    {
      public override void ProcessMessage(SoapMessage message)
      {
        switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    {
                        // web service client object
                        var webserviceobject= ((SoapClientMessage)message).Client;
                        // method from web service that was called
                        var calledMethod = (SoapClientMessage)message).MethodInfo;
                        // checked the client type of webserviceobject and
                        //added method / property specific logic here
                     }
             }
      }
      // other soap extension code
    }

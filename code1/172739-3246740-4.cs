    class SomeConsumer
    {
        private Action<string,string> m_SendDelegate;
        public SomeConsumer( Action<string,string> sendDelegate ) 
        { 
            m_SendDelegate = sendDelegate;
        } 
        public DoSomething()
        {
            // uses the supplied delegate to send the message
            m_SendDelegate( "Text to be sent", "destination" ); 
        }
    }
    var consumerA = new SomeConsumer( TextClient.Send ); // sends text messages
    var consumerB = new SomeConsumer( MailClient.Send ); // will send emails

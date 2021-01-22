    public class ChatBox
    {
        public ChatBox(Messenger messenger)
        {
            messenger.Delivery += OnMessageDelivery;
        }
        private void OnMessageDelivery(object sender, MessageHandlerDeliveryEventArgs e)
        {
            if(e.Message.Type == MessageType.Chat)
            {
                Print(String.Format("{0}: {1}", e.DateTime, e.Message.Text));
            }
        }
    }

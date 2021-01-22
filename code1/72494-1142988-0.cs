    static class Message
    {
        public static void Send(String message)
        {
             Send(message, true);
        }
    
        private void static Send(string messageToSend, bool requiresACK)
        {
            SendMessageDelegate sendDelegate = DoSend;
            IAsyncResult ar = sendDelegate.BeginInvoke(messageToSend, requiresACK);
    
            //rest of function
        }
    }

    public static class Messenger
    { 
        private static IReceiver recv = null;
        
        // Initialize the receiver of the messages
        public static void InitializeReceiver(IReceiver f)
        {
            recv = f;
        }
        // Send a message to the receiver
        public static void SendMessage(string message)
        {
            if(recv != null) recv.WriteMessage(message);
        }
    }

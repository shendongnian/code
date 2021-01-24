    public static class Messenger
    { 
        private static IReceiver recv = null;
        
        // Initialize the receiver of the messages
        public static void InitializeReceiver(IReceiver f)
        {
            recv = f;
        }
        // Call whatever class instance has been passed in the Initialize
        // we know for sure that there is a WriteMessage method to call
        public static void SendMessage(string message)
        {
            if(recv != null) recv.WriteMessage(message);
        }
    }

    public static class Messenger
    { 
        private static IReceiver recv = null;
        
        // Initialize the internal variable recv with the instance 
        // passed. We don't care what type is, we are only interested
        // in a class that implements the IReceiver interface
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

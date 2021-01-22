    //Handler class
    public class Speaker {
        public delegate void HandleMessage(string message);
        public event HandleMessage OnMessage;
        public void SendMessage(string message) {
            if (OnMessage != null) { OnMessage(message); }
        }
    }
    //then used like...
    Speaker handler = new Speaker();
    handler.OnMessage += (message) => { Console.WriteLine("Woofer: {0}", message); };
    handler.OnMessage += (message) => { Console.WriteLine("Tweeter: {0}", message); };
    handler.SendMessage("Test Message");

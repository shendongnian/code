    public class MyHub : Hub
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Incoming message {0}", message);
        }
    }

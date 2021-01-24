    public class Message
    {
        private readonly string _json;
        public Message(string json)
        {
            _json = json;            
        }
        public string GetBody() // not generic, but you get the idea now.
        {
            return json;
        }
    }

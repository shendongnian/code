    public class MessageUserTest
    {
        public void Use()
        {
            // your code to get a message here...
            QueueMessage<string> msg = null; 
            // emulate pattern matching, but without constructor names
            int i =
                msg.Match(
                    () => -1,
                    () => -2,
                    s => s.Length);
        }
    }

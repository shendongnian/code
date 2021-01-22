    public class MessageUserTest
    {
        public void Use()
        {
            // your code to get a message here...
            QueueMessage<string> msg = null; 
            // emulate pattern matching, but without constructor names
            int i =
                msg.Match(
                    clearCase:      () => -1,
                    tryDequeueCase: () => -2,
                    enqueueCase:     s =>  s.Length);
        }
    }

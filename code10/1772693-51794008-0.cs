    public class Bar : IFoo<Message1D, Message1D>, IFoo<Message1D, Message>
    {
        public Message1D PassMessage(Message1D input)
        {
            // ...
        }
        Message1D IFoo<Message1D, Message>.PassMessage(Message input)
        {
            try
            {
                return PassMessage((Message1D) input);
            }
            catch (InvalidCastException)
            {
                // Message2D passed, handling exception
                // ...
            }
        }

    public abstract class MessageBase { }    
    
    public class Message1D : MessageBase { }
    public class Message2D : MessageBase { }
    
    public interface IFoo<out T> where T : MessageBase { }
    
    public class Bar : IFoo<Message1D> { }
    public class Baz : IFoo<Message2D> { }    
    
    public class Network
    {
        private List<IFoo<MessageBase>> messages = new List<IFoo<MessageBase>>();
    
        public void AddBar()
        {
            messages.Add(new Bar());
        }
    
        public void AddBaz()
        {
            messages.Add(new Baz());
        }
    }

    public interface ILog {
      MessageCollection Messages {get;}
      void AddMessage(Message message); // Additional method.
    }
    public class MessageCollection : Collection<Message>{
      // Addional methods.
    }

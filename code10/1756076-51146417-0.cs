    public interface IInterface<T>
    {
     void Handle(T message);
     int Order {get;}
    }
    
    public class A: IInterface<T>
    {
      void Handle(T Message) {}
      public int Order => 1;
    }
    
    public class B: IInterface<T>
    {
      void Handle(T Message) {}
      public int Order => 0;
    }
    
    foreach (var commandHandler in commandHandlers.OrderBy(o=>o.Order))
    {
        commandHandler.Handle(message);
    }

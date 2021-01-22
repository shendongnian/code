    public interface IAddableThings
    {
      int a;
      int b;
    }
    
    public interface IOtherAddableThings : IAddableThings
    {
      int a;
      int b;
    }
    
    public interface IServerComponent
    {
        bool Add(IAddableThings things);
    }

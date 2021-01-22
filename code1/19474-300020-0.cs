    interface IAction
    {
       void action();
    }
    
    class ObjectType1 : IAction
    {
       void action() {
          Console.WriteLine("1");
       }
    }
    
    class ObjectType2 : IAction
    {
        void action() {
          Console.WriteLine("2");
        }
    }
    
    class Parser
    {
       public IAction execute(IAction obj)
       {
          obj.action();
          return obj;
       }
    }

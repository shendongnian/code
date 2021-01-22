        public interface IInterfaceBase
        {
 
        }
        public interface IInterface1 : IInterfaceBase
        {
          ...
        }
        public interface IInterface2 : IInterfaceBase
        {
          ...
        } 
        public static void DoSomething<T>() where T: IInterfaceBase
        {
        }

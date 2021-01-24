    class Program
    {
      static void Main(string[] args)
      {
        List<IIntf> list = new List<IIntf>()
        {
          new AClass(),
          new BClass(),
        };
        list.RemoveAll(i => i.GetType() == typeof(BClass));
      }
    }
    public interface IIntf { }
    public class AClass : IIntf { }
    public class BClass : IIntf { }

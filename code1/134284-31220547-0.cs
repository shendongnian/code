    public interface IDemo1
    {
     void Test();
    }
    public interface IDemo2
    {
     void Test();
    }
    public class clsDerived:IDemo1,IDemo2
    {
      void IDemo1.Test() 
      {
       Console.WriteLine("IDemo1 Test is fine");
      }
     void IDemo2.Test() 
      {
        Console.WriteLine("IDemo2 Test is fine");
      }
    }
    public void get_methodes()
    {
        IDemo1 obj1 = new clsDerived();
        IDemo2 obj2 = new clsDerived();
        obj1.Test();//Methode of 1st Interface
        obj2.Test();//Methode of 2st Interface
    }

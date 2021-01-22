    using NRoles;
    public interface IFirst { void FirstMethod(); }
    public interface ISecond { void SecondMethod(); }
    public class RFirst : IFirst, Role {
      public void FirstMethod() { Console.WriteLine("Frist"); }
    }
    public class RSecond : ISecond, Role {
      public void SecondMethod() { Console.WriteLine("Second"); }
    }
    public class FirstAndSecond : Does<RFirst>, Does<RSecond> { }

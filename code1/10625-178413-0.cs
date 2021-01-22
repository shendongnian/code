    public interface IFirst {}
    public interface ISecond {}
    
    public class FirstAndSecond : IFirst, ISecond
    {
    }
    
    public static MultipleInheritenceExtensions
    {
      public static void First(this IFirst theFirst)
      {
        Console.WriteLine("First");
      }
    
      public static void Second(this ISecond theSecond)
      {
        Console.WriteLine("Second");
      }
    }
///
    public void Test()
    {
      FirstAndSecond fas = new FirstAndSecond();
      fas.First();
      fas.Second();
    }

    class Program
       {
          static void Main(string[] args)
          {
             var childClass1 = new ChildClass1();
             var childClass2 = new ChildClass2();
             childClass1.IncrementCounter();
             childClass2.ConsoleLogCounter();
          }
       }
    
       public class BaseClass
       {
          public static int counter;
       }
    
       public class ChildClass1 : BaseClass
       {
          public void IncrementCounter()
          {
             counter++;
          }
       }
    
       public class ChildClass2 : BaseClass
       {
          public void ConsoleLogCounter()
          {
             Console.WriteLine(counter);
          }
       }

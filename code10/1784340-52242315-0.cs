     public interface IReceiverBase
     {
         void ReceiveMessage(string message);
     }
 
     public class Report
     {
         private readonly IReceiverBase _iReceiverBase;
 
         public Report(IReceiverBase iReceiverBase)
         {
             _iReceiverBase = iReceiverBase;
         }
 
         public void DoSomething()
         {
             // Do something here
             _iReceiverBase.ReceiveMessage("Something done ...");
         }
     }
 
     public class ConsoleMessageReceiver : IReceiverBase
     {
         public void ReceiveMessage(string message)
         {
             Console.WriteLine(message);
         }
     }
 
     public class DebugMessageReceiver : IReceiverBase
     {
         public void ReceiveMessage(string message)
         {
             Debug.WriteLine(message);
         }
     }
 
     class Program
     {
         static void Main(string[] args)
         {
             var repConsole = new Report(new ConsoleMessageReceiver());
             repConsole.DoSomething();
 
             var repDebug = new Report(new DebugMessageReceiver());
             repDebug.DoSomething();
 
             Console.Read();
         }
     }

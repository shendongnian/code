      public abstract class StringHandler
      {
        public abstract bool CanProcess(string input);
        public abstract void Process();
      }
    
      public class HelloStringHandler : StringHandler
      {
        public override bool CanProcess(string input)
        {
          return input.Equals("hello");
        }
    
        public override void Process()
        {
          Console.WriteLine("HELLO WORLD");
        }
      }

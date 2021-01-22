    public interface Command
    {
      public void execute();
      public String getName();
    }
    public class Blur implements Command
    {
      // ...
      public Blur(String name)
      {
        // ...
      }
      //...
      
      public void execute()
      {
        // execute the blur command
      }
    }

    public interface IDoesCoolThings 
    {
       void DoCool();
    }
    public abstract class AbstractWidget 
    {
       public void DoCool()
       {
          Console.WriteLine("I did something cool.");
       }
    }
    public class Widget : AbstractWidget, IDoesCoolThings 
    {
    }

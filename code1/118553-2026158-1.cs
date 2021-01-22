    public abstract class A
    {
     public void Display(){}
    }
    public class B:A
    {
     public void SomethingThatCallsDisplay()
     {
      Display();
     }
    }

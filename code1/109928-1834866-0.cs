    public interface MyInputInterface
    {
            void YourInputFunction();
    }
    
    public class CalculatorPanel : Control, MyInputInterface
    {
       ..
       ..
    
       void MyInputInterface.YourInputFunction()
       {
           // do your code specific to calculator panel here
       }
    }
    
    public class GraphPanel : Control, MyInputInterface
    {
       ..
       ..
    
       void MyInputInterface.YourInputFunction()
       {
           // do your code specific to graph panel here
       }
    }

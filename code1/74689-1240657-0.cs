    public interface ISimpleSample
    {
      string Name {get;}
      int ID {get;}
    }
    
    public interface IAdvancedSample
    {
      string Name {get; set;}
      int ID {get; set;}
      string Make {get; set;}
      string Model {get; set;}
    }
    
    public class Sample : ISimpleSample, IAdvancedSample
    {
      //Implementation skipped
    }

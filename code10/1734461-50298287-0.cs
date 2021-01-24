    public interface ISampleRepository : IDisposable
    {
         IEnumerable<SampleModel> GetAllSamples();
    }
    
    public class SampleContext : ISampleRepository
    {
         public IEnumerable<SampleModel> GetAllSamples()
         {
              // Implementation
         }
    }
    
    public interface ISampleFactory
    {
         ISampleRepository Create();
    }
    
    public class SampleFactory
    {
         ISampleRepository Create() => new SampleContext();
    }

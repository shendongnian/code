    public interface ISampleFactory
    {
         IDataBinder<SampleModel> Create();
    }
    
    public class SampleFactory
    {
         public IDataBinder<SampleModel> Create() => new SampleContext();
    }

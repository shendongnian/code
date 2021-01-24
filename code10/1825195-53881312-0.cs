    public interface ISampleType
    {
        Func<AnotherClass, object> GroupingKey { get; }
    }
    public class SampleType1 : ISampleType
    {
        public Func<AnotherClass, object> GroupingKey => a => a.Property1;
    }
    public class SampleType2 : ISampleType
    {
        public Func<AnotherClass, object> GroupingKey => a => a.Property2;
    }
    void Main()
    {
        var list = new List<AnotherClass>();
        ISampleType sample = new SampleType1();
    
        var result = list.GroupBy(sample.GroupingKey);
    }

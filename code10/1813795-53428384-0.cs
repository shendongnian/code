    public interface IQualifiersProvider
    {
        IEnumerable<IQualifier> GetQualifiers();
    }
    public class QualifiersProvider : IQualifiersProvider
    {
        //from db / whatever
        public IEnumerable<IQualifier> GetQualifiers()
        {
            return new [] {
                new Qualifier(),
                new Qualifier(),
            }
        }
    }

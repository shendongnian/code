    public interface ITest
    {
        IList<object> SkuDetails { get; }
    }
    
    public class OutTest : ITest
    {
        public IList<object> SkuDetails { get; set; }
    }

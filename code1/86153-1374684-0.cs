    public interface IDataAdapter
    {
        object Transform(object input);
    }
    public interface IDataAdapter<OutT, InT> : IDataAdapter
    {
        OutT Transform(InT input);
    }
    public class SomeClass : IDataAdapter<string, string>
    {
        public string Transform(string input)
        {
            // Do something...
        }
        public object Transform(object input)
        {
            // Do something...
        }
    }

    public interface IFileParser<TResponse>
        {
            TResponse Parse(string file);
        }
    
        public class CarFileParser : IFileParser<List<CarData>>
        {
            public List<CarData> Parse(string file)
            {
                throw new NotImplementedException();
            }
        }

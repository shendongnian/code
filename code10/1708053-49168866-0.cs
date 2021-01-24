    // Put the type of data on the interface / type
    public interface IFileParser<TData>
    {
        IEnumerable<TData> Parse(string file);
    }
  
    // Implement the interface
    public class CarParser : IFileParser<CarData>
    {
        ...
    }
    // Specify what implementation you want
    IFileParser<CarData> _carParser = new CarFileParser();
    // Then just call parse (no parameters required)
    var carData = _carParser.Parse(file);

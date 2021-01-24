    public interface IName
    {
        string Name { get; }
    }
    public struct Creature : IName
    {
        ...
    }
    public static string ListToString<T>(List<T> list, bool formatted) where T : IName
    {
        ... //The compiler now knows that T is guaranteed to implement IName.
    }
      

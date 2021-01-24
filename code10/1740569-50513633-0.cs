    public abstract class Part<T>
    {
       public abstract Maker<T> GetMaker();
    }
    public class Maker<T>
    {
       public string Name { get; set; } = "";
    }

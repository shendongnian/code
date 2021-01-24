    public interface IMaximumCapacity
    {
       int MaximumCapacity { get; set; }
    }
    
    public class BaseRoom
    {
    
    }
    
    public class DerivedRoom : BaseRoom, IMaximumCapacity
    {
       public int MaximumCapacity { get; set; }
    }

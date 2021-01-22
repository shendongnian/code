    public interface IPrimaryKey 
    {
    }
    public class PrimaryGuidKey(Guid key) : IPrimaryKey 
    public class PrimaryIntegerKey(int key) : IPrimaryKey
    private static OurCustomObject<T>(T identifier) where T : IPrimaryKey

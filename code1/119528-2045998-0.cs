    public interface ICachable
    {
        Guid ClassId { get; }
    }
    public class Person : ICachable
    {
        public Guid ClassId
        {
            get {  return new Guid("DF9DD4A9-1396-4ddb-98D4-F8F143692C45"); }
        }
    }

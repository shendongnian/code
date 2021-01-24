    public interface IReadOnlInterface
    {
       int Id { get; }
       string Name { get; }
    }
    public interface IInterface
    {
          int Id { get; set; }
          string Name { get; set; }
    }
    
    internal class Thing : IInterface , IReadOnlInterface
    {
       public int Id { get; set; }
       public string Name { get; set; }
    }

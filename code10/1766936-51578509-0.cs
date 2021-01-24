    interface IEntity<T>
    {
        T Id { get; set; }
    }
    
    public class Employee : IEntity<int>
    {
        public int Id { get; set; }
    }

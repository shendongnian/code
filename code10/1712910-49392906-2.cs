    public interface ICustomer
    { 
        Guid CustomerGuid { get; }
    }
    
    public abstract class BaseCustomer<T>: ICstomerInterface<T>, ICustomer
    {
        ///etc....

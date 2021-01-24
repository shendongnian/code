    public interface IEntityController<out T> where T : IBaseEntity
    {
    	
    }
    
    public abstract partial class DefaultController<T>: Controller, IEntityController<T> 
        where T : IBaseEntity
    {
    
    }

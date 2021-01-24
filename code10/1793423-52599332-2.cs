    public interface IEntityController
    {
    	
    }
    
    public abstract partial class DefaultController<T>: Controller, IEntityController
        where T : IBaseEntity
    {
    
    }
...
        var controller = filterContext.Controller as IEntityController; 

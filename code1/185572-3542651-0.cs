    abstract class AbstractClass
    {
    }
    
    abstract class AbstractClass<TModel> : AbstractClass
        where TModel : ModelObject 
    {
       static public TModel Model;
       ...
    }

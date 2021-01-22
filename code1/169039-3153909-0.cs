    public class MyClass<E> where E : IEntity, class
    {
       IMyInterface<E> businessLogic;
       public setBusinessLogic(IMyInterface<E> myObject)
       {
           businessLogic = myObject;
       }
    }

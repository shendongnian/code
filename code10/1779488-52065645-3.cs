    public class ImplementationB:IModel
    {
       public void Dosomething(IModelImpl model)
       {
           //Do more specific work to ImplementationB like validation
           model.Do();
       }
    }

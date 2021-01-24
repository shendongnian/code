    public class BasePetController  {
      protected IResource[] resources;
      public BasePetController (IResource[] resources)
      {
        this.resources = resources;
      }
    }
    public class DogController : BasePetController 
    {
      public DogController(IResource[] resources): base (resources)
    }
    public class CatController  : BasePetController
    {
      public CatController(IResource[] resources): base (resources)
    }
    public class DogResource : IResource 
    {
    }
    public class DogResource : IResource 
    {
        
    }
    public interface IResource{
      
    }
    services.AddSingleton<DogResource, IResource>();
    services.AddSingleton<CatResource, IResource>();

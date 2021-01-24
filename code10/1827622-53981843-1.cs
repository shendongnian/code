    public DogController {
    public DogController(IDogResource dogResource)
    }
    public CatController {
       public CatController(ICatResource dogResource)
    }
    public interface IDogResource : IResource
    {
    }
    public interface ICatResource : IResource
    {
    }
    public interface IResource{
      //your common logic
    }
    services.AddSingleton<DogResource, IDogResource>();
    services.AddSingleton<CatResource, ICatResource>();

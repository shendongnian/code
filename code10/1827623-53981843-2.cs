    public BasePetController  {
      protected IResource resource;
      public BasePetController (IResource resource)
      {
          this.resource = resource;
      }
    }
    public DogController : BasePetController 
    {
      public DogController(IDogResource dogResource): base (dogResource)
    }
    public CatController  : BasePetController
    {
      public CatController(ICatResource dogResource): base (dogResource)
    }

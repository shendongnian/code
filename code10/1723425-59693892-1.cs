    private UnitOfWork _unitOfWork;
    
    public MoviesController(MyDBContext context)
    {
          _unitOfWork = new UnitOfWork(context);
    }

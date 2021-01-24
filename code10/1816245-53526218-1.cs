    IEmployeesRepo _repo;
    public EmployeesController(IEmployeesRepo repo)
    {
        _repo = repo;
    }
...
    private readonly EFContext _db;
    private readonly IMapper _mapper;
    // Assign the object in the constructor for dependency injection
    public EmployeesRepo(DBContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    class AnotherClass
    {
     public string Name {get;set;}
    }
    IRepositoryTest<UserRoles> _userRolesRepository = null;
    IRepositoryTest<AnotherClass> _anotherRepository = null;
    public DashbrdController(IRepositoryTest<UserRoles> userRolesRepository, IRepositoryTest<AnotherClass> anotherRepository)
    {
        this._userRolesRepository = userRolesRepository;
        this._anotherRepository=anotherRepository;
    }
    public DashbrdController()
    {
        this._userRolesRepository = new RepositoryTest<UserRoles>();
        this._anotherRepository = new RepositoryTest<AnotherClass>();
    }
    public ActionResult DashBrd()
    {
        var rslt = _userRolesRepository.SelectAll(s=>s.user_id=="myName");         
        return View();
    }
    public ActionResult AnotherDashBrd()
    {
        var anotherrslt = _anotherRepository.SelectAll(s=>s.Name=="myName");         
        return View();
    }

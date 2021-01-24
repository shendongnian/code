    public class DashbrdController:Controller
    { 
     TransactionManager _tMgr;
    public DashbrdController(TransactionManager tMgr)
    {
        this._tMgr=tMgr;
    }
    public DashbrdController()
    {
        this._tMgr=new TransactionManager() ;
    }
    public ActionResult DashBrd()
    {
        var rslt = _tMgr.CreateRepository<UserRoles>().SelectAll(s=>s.user_id=="myName");         
        return View();
    }
    public ActionResult AnotherDashBrd()
    {
        var anotherrslt = _tMgr.CreateRepository<AnotherRoles>().SelectAll(s=>s.Name=="myName");         
        return View();
    }

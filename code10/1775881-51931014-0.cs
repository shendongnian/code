    public class RegisterController : Controller
        {
            #region Properties
            private IRegisterService _registerService;
            private readonly RegisterDbContext _registerDbContext;   //Replace it with your custom <DbContext> class
            #endregion
    
            #region Constructor
            public RegisterController(IRegisterService registerService)
            {
                _registerService = registerService;
                _registerDbContext = new RegisterDbContext();
            }
            #endregion
    
            #region Actions
            [HttpPost]
            public ActionResult Create(RegisterDTO registerDTO)
            {
                //You can use Db Transactions to add data 
                using (var dbContextTransaction = _registerDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //Assuming this class as Database Entity refering to Register table in Database
                        Register register = new Register();
                        register.FirstName = registerDTO.FirstName;
                        register.LastName = registerDTO.LastName;
                        register.UserName = registerDTO.UserName;
                        register.Password = registerDTO.Password;
                        _registerDbContext.Register.Add(register);
                        _registerDbContext.SaveChanges();
    
                        //Assuming this class as Database Entity refering to UserLogin table in Database
                        UserLogin userLogin = new UserLogin();
                        userLogin.UserName = registerDTO.UserName;
                        userLogin.Password = registerDTO.Password;
                        _registerDbContext.UserLogin.Add(userLogin);
                        _registerDbContext.SaveChanges();
    
    
                        dbContextTransaction.Commit();
                        return View();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            #endregion
        }

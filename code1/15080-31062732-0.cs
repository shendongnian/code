    using LoginApi = MyCompany.Api.Login;
    using AuthDB = MyCompany.DataBase.Auth;
    using ViewModels = MyCompany.BananasPortal.Models;
    // ...
    AuthDB.User dbUser;
    using ( var ctxt = new AuthDB.AuthContext() )
    {
        dbUser = ctxt.Users.Find(userId);
    }
    
    var apiUser = new LoginApi.Models.User {
            Username = dbUser.EmailAddess,
            Password = "*****"
        };
    LoginApi.UserSession apiUserSession = await LoginApi.Login(apiUser);
    var vm = new ViewModels.User(apiUserSession.User.Details);
    return View(vm);

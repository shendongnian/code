    var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
    ApplicationUserManager _userManager = new ApplicationUserManager(store);
    var usermanager = _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var user = new ApplicationUser { UserName = regitem.Email.Trim(), Email = regitem.Email.Trim(), Fname = regitem.Fname.Trim(), Lname = regitem.Lname.Trim(), OrgID = OrgID, RegistrationDate = regitem.RegistrationDate ?? DateTime.Now, LastLoginDate = regitem.LastLoginDate, EmailConfirmed = true, PhoneNumber = regitem.PhoneNumber };
    var result = usermanager.Create(user, regitem.Password);

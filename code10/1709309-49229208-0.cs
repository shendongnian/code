        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VmUser_User VmUser_User)
        {
            if (VmUser_User.User_User.UserName == null ||
            VmUser_User.User_User.Password == null)
            {
                VmUser_User.LblError = "Please enter Username and Password";
                return View(VmUser_User);
            }
            //Return valid user
            if (VmUser_User.LoginUser() > 0)
            {
                Session["One"] = VmUser_User;
                if (Request.QueryString["ReturnUrl"] != null & Request.QueryString["ReturnUrl"] != "")
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                VmUser_User.LblError = "User/Password does not match!";
            }
            return View(VmUser_User);
        }
        //And another Action Method
        public async Task<ActionResult> Common_Unit()
        {
            Oss.Romo.ViewModels.User.VmUser_User user =
            (Oss.Romo.ViewModels.User.VmUser_User)Session["One"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home", new { ReturnUrl = "/Common/Common_Unit" });
            }
            vmCommon_Unit = new VmCommon_Unit();
            await Task.Run(() => vmCommon_Unit.InitialDataLoad());
            return View(vmCommon_Unit);
        } 

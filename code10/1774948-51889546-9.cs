    public ActionResult AccountList(string Id, string Bvalue)
    {       
        UserData userData = Session["info"] as UserData;
        if (userData.RoleCode != "4")
        {
            return RedirectToAction("LogOut", "Login");
        }
        BusinessLogicResult Result = new AccountListSearchLogic().doProcess(
                                           new BusinessLogicInput() {
                                               UserInfoData = userData,
                                               BvalueAction = Bvalue  
                                           }
                                     );
        var UserList = Result[AccountListSearchLogic.KEY_OUT_USER_LIST] 
                             as List<AccountUserListView>;
        return View(new MyViewModel(UserList, Bvalue));
    }

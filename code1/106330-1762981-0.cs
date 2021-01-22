    public ActionResult myItems() {
        var dataContext = new RecordsDataContext();
        MembershipUser myObject = Membership.GetUser();         
        string CurrentUserName = myObject.UserName.ToString();    
        var user = from i in dataContext.myUsers
                   where i.userName == CurrentUserName
                   select i.id;
        if (user.Count == 1) //found one
        {
            var items = from j in dataContext.OtherUsers
                        where j.id_user == user.First()
                        select j;
            return View(items);
        }
        return View(new ActionResult());
    }

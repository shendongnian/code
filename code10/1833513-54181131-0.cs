    [HttpPost]
    public ActionResult CreateUserWithPhone(FormCollection fc)
    {
        ...
        using (var context = new UsersPhonesDBContext())
        {
            var user= new Users { Name = "testName" };
            user.Phones.Add(new Phones{ Model= "testModel" });
            context.Users.Add(user);
            context.SaveChanges();
        }
        ...
    }

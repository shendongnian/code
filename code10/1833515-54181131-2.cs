    [HttpPost]
    public ActionResult CreateUserWithPhone(FormCollection fc)
    {
        ...
        using (var context = new UsersPhonesDBContext())
        {
            var user= new Users { Name = "testName" };
            context.Users.Add(user);
 
            var phone = new Phones{ Model= "testModel" };
            context.Phones.Add(phone);
            user.Phones = new List<Phones>();
            user.Phones.Add(phone);
            
            context.SaveChanges();
        }
        ...
    }

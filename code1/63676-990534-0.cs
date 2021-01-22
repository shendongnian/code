    using (NetTanitimTestEntities newadmin = new NetTanitimTestEntities())
    {
         Admins admin = new Admins { Name = "ali", SurName = "Çorlu", Username = "acorlu", Password = "1234", UserType = "user" };
         newadmin.AddToAdmins(admin);
         newadmin.SaveChanges();
    }

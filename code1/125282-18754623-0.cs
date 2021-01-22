    using (var userObject = UserObject.FindOneByCN(this.ADOperator, “pangxiaoliang”))
    {
         if(userObject.Email == "example@landpy.com")
         {
              userObject.Email = "mv@live.cn";
              userObject.Save();
         }
    }

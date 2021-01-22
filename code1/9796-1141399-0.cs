        public void GuestUserTest()
        {
            SlideLincEntities ctx1 = new SlideLincEntities();
            GuestUser user = GuestUser.CreateGuestUser();
            user.UserName = "Something";
            ctx1.AddToUser(user);
            ctx1.SaveChanges();
            SlideLincEntities ctx2 = new SlideLincEntities();
            ctx1.Detach(user);
            user.UserName = "Something Else";
            ctx2.Attach(user);
            ctx2.SaveChanges();
        }

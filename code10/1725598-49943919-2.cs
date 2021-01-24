    public static MyContextExtensions
    {
        public static User Given(this MyContext @this, User user)
        {
            @this.Users.Add(user);
            @this.SaveChanges();
            return user;
        }
        public static OtherEntity Given(this MyContext @this, OtherEntity otherEntity)
        {
             // ...
        }
        // ...
    }

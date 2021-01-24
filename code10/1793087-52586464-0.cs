    class User
    {
         public int Id {get; set;}
         // every User has zero or more Profiles (many-to-many)
         public virtual ICollection<Profile> Profiles {get; set;}
         ...
    }
    class Profile
    {
         public int Id {get; set;}
         // every Profile belongs to zero or more Users (many-to-many)
         public virtual ICollection<User> Userss {get; set;}
         ...
    }

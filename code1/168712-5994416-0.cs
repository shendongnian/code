    class User
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<Profile> Profiles { get; set; }
    }
    class Profile
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<User> Users { get; set; }
    }

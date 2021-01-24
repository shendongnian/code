          public DogFaceDbContext()
        {
        }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<UserDog> UserDogs { get; set; }
        public virtual DbSet<DogFriend> DogFriends { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Database.Create();
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DataContext()
            : base(nameOrConnectionString: "ConnStringName")
        {
            Database.SetInitializer<DataContext>(null);
        }

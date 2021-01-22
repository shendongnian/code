        public const string ConnectionString = "name=My_Entities";
        public const string ContainerName = "My_Entities";
    
        #region Constructors
    
        public My_Entities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
     
        #endregion

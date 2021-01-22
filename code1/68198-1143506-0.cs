        [Table( Name="TBL_REGISTRATION" )]
        public sealed class Registration : IDataErrorInfo
        {
                public Guid RegistrationID { get { return _registrationID; } }
    
                [Column( IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
                private Guid _registrationID; 
    }

    [Table( Name="TBL_REGISTRATION" )]
    public sealed class Registration : IDataErrorInfo
    {
            [Column( Name="TBL_REGISTRATION_PK", Storage="_RegistrationID", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert )]
            public Guid RegistrationID { get { return _RegistrationID; } set { _RegistrationID = value; } }
            
            private Guid _RegistrationID;
        /* other properties ommited for brevity */
    }

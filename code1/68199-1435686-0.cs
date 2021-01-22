    // Primary key to TBL_REGISTRATIONT
    [Column( Name = "TBL_REGISTRATIONT_PK", IsDbGenerated = true, AutoSync = AutoSync.OnInsert )]
    public Guid RegistrationID
    {
        get
        {
            return TBL_REGISTRATIONT_PK;
        }
        private set
        {
            TBL_REGISTRATIONT_PK = value;
        }
    }
    [Column( IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert )]
    private Guid TBL_REGISTRATIONT_PK;

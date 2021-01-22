    public enum AccessLevelEnum
        {
            /// <summary>
            /// The user cannot access
            /// </summary>
            [EnumMember, Description("No Access")]
            NoAccess = 0x0,
    
            /// <summary>
            /// The user can read the entire record in question
            /// </summary>
            [EnumMember, Description("Read Only")]
            ReadOnly = 0x01,
    
            /// <summary>
            /// The user can read or write
            /// </summary>
            [EnumMember, Description("Read / Modify")]
            ReadModify = 0x02,
    
            /// <summary>
            /// User can create new records, modify and read existing ones
            /// </summary>
            [EnumMember, Description("Create / Read / Modify")]
            CreateReadModify = 0x04,
    
            /// <summary>
            /// User can read, write, or delete
            /// </summary>
            [EnumMember, Description("Create / Read / Modify / Delete")]
            CreateReadModifyDelete = 0x08,
    
            /*/// <summary>
            /// User can read, write, or delete
            /// </summary>
            [EnumMember, Description("Create / Read / Modify / Delete / Verify / Edit Capture Value")]
            CreateReadModifyDeleteVerify = 0x16*/
        }

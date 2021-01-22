    public class UserProfile
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty]
        public string EmployeeID { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty]
        public string GivenName { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty("SN")]
        public string Surname { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty]
        public string Company { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty]
        public string Department { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty("CN")]
        public string UserName { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty("Mail")]
        public string Email { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [ActiveDirectoryProperty]
        public LanguageType Language { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public DateTime? NextPasswordChangeDate { get; set; }
    }

    [DataContract(Namespace = "http://namespace.mydomain.com/2009/05", Name = "ReferenceTypeData")]
    public enum GenderEnum
    {
        [EnumMember()]
        Unknown = 0,
        [EnumMember()]
        Male = 1,
        [EnumMember()]
        Female = 2
    }

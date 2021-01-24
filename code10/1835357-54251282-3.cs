    [Flags]
    public enum ElementsTag
    {
        None = 0,
        Surname         = 1,
        SecondSurname   = 1 << 1, // 2
        Forenames       = 1 << 2,  // 4
        PersonalNumber  = 1 << 3, // 8
        Birthday        = 1 << 4,
        Nationality     = 1 << 5,
        DocumentExpirationDate = 1 << 6,
        DocumentNumber         = 1 << 7,
        Sex                    = 1 << 8,
        CityOfBirth            = 1 << 9,
        ProvinceOfBirth        = 1 << 10,
        ParentsName            = 1 << 11,
        PlaceOfResidence       = 1 << 12,
        CityOfResidence        = 1 << 13,
        ProvinceOfResidence    = 1 << 14
    }

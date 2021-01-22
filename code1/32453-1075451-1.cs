    public static void AddPhoneNumberToContact<T>(
        this T contact,
        PhoneType type,
        String number
    )
    {
        PhoneRow pr = PhoneRow.CreateNew();
        pr.SetDefaults();
        pr.PtypeIdx = type;
        pr.PhoneNumber = number;
        ((T)contact).Phones.Add(pr);
        pr = null;
    }

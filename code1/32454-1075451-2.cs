    public static void AddPhoneNumberToContact<T>(
        this T contact,
        PhoneType type,
        String number
    ) where T : IPhoneable {...}

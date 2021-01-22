    static bool IsValidPhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrEmpty(phoneNumber)
            && (phoneNumber.Length <= 25)
            && phoneNumber.All(c => char.IsNumber(c));
    }

    public static string ToArabic(long num)
    {
        const string _arabicDigits = "۰۱۲۳۴۵۶۷۸۹";
        return new string(num.ToString().Select(c => _arabicDigits[c - '0']).ToArray());
    }

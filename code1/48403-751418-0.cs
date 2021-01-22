    public static bool IsNullOrEmpty(this string value){
        return string.IsNullOrEmpty(value);
    }
    public static string Reverse(this string value) {
        if (!string.IsNullOrEmpty(value)) {
            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            value = new string(chars);
        }
        return value;
    }
    public static string ToTitleCase(this string value) {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }
    public static string ToTitleCaseInvariant(this string value) {
        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
    }

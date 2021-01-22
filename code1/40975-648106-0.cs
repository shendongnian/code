    using System.Linq;
    ...
    
    public static bool IsPrintableAscii(this string value)
    {
        return value != null && value.All(c => c >= 32 && c < 127);
    }

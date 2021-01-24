    private static string GetSystemTimeFormat()
    {
        return Registry
            .GetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortTime", "x")
            .ToString()
            .Contains("h")
            ? "AM/PM"
            : "24-hour";
    }

    private static int GetEnabledStatus()
    {
        const int defaultStatus = 0;
        using (var key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\myApp")) // open read-only
        {
            int valueInt;
            var value = (key != null
                ? key.GetValue("enabled", defaultStatus)
                : defaultStatus);
            return (value is int
                ? (int)value
                : int.TryParse(value.ToString(), out valueInt)
                    ? valueInt
                    : defaultStatus);
        }
    }

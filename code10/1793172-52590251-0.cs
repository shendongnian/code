    # v5
    [Uri]::EscapeUriString("[]") # OUTPUT: "%5B%5D"
    # for reference
    Add-Type "
    using System;
    namespace PowerShell
    {
        public static class Uri
        {
            public static string EscapeUriString(string stringToEscape)
            {
                return System.Uri.EscapeUriString(stringToEscape);
            }
        }
    }"
    [PowerShell.Uri]::EscapeUriString("[]") # OUTPUT: "%5B%5D"

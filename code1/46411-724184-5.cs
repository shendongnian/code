     public static class FILETIMEExtensions {
            public static DateTime ToDateTime(this System.Runtime.InteropServices.ComTypes.FILETIME filetime ) {
                long highBits = filetime.dwHighDateTime;
                highBits = highBits << 32;
                return DateTime.FromFileTimeUtc(highBits + (long)filetime.dwLowDateTime);
            }
        }

    public static class EnumExtensions 
    { 
        public static string NumberString(this Enum enVal) 
        { 
            return enVal.ToString("D"); 
        }
    } 

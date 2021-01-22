    public static class GdiCharHelper
    {
        public static string ToGdiName(this byte GdiCharSet)
        {
                return Enum.GetName(typeof(CharSet), GdiCharSet);
        }
    }

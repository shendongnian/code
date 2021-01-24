        public static class Helper
        {
             public static Color GetColor()
             {
                   var hexValue = ConfigurationManager.AppSettings["colorHex"];
                   private static Color _backgroundColor = Color.FromHex(hexValue);
                   return _backgroundColor;
             }
        }

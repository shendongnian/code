    public class YourSurroundingClass {
        private static readonly string CookieName;
        
        static YourSurroundingClass() {
            CookieName = "TempData" + DateTime.Now.Ticks
                .ToString();
        }
    }

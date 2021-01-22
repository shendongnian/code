    public interface ColorScheme {
        Color TitleBar { get; }
        Color Background{ get; }
        ...
    }
    public static class ColorSchemeFactory {
    
        private static ColorScheme scheme = new Outlook2007ColorScheme();
    
        public static ColorScheme GetColorScheme() { //Add applicable arguments
            return scheme;
        }
    }
    public class Outlook2003ColorScheme: ColorScheme {
       public Color TitleBar {
           get { return Color.LightBlue; }
       }
        public Color Background {
            get { return Color.Gray; }
        }
    }
    public class Outlook2007ColorScheme: ColorScheme {
       public Color TitleBar {
           get { return Color.Blue; }
       }
        public Color Background {
            get { return Color.White; }
        }
    }

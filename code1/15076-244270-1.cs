    public interface ColorScheme {
        Color TitleBar { get; }
        Color Background{ get; }
        ...
    }
    public static ColorSchemeFactory {
    
        private static ColorScheme scheme = new Outlook2007ColorScheme();
    
        public static ColorScheme ColorScheme {
            get { return scheme; }
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

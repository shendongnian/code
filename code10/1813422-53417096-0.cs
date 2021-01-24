    public interface IDesktopProperties
    {
        Color BackColor {get; set;}
        Color MouseOverBackColor {get; set;}
    }
    
    public interface IMobileProperties
    {
        Color BackColor {get; set;}
        Orientation ScreenOrientation {get; set;}
    }
    
    public class MySuperFancyViewModel : IDesktopProperties, IMobileProperties
    {
        public Color BackColor {get; set;}
        public Color MouseOverBackColor {get; set;}
        public Orientation ScreenOrientation {get; set;}
    }

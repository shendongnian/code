    public enum IconImage
    {
        Save, Open, Print,
        Check, Tickbox, CheckedTickbox,
        // ...
    }
    public static class IconImages
    {
        public static class Application
        {
            public static readonly IconImage
                Save = IconImage.Save,
                Open = IconImage.Open,
                Print = IconImage.Print;
        }
        public static class Marks
        {
            public static readonly IconImage
                Check = IconImage.Check,
                Tickbox = IconImage.Tickbox,
                CheckedTickbox = IconImage.CheckedTickbox;
        }
    
        // … other category classes …
    }
    // Usage: control.Icon = IconImage.Print  -- or --  control.Icon = IconImages.Application.Print
    // XAML: Icon="Print" -- or -- Icon="{x:Static local:IconImages.Application.Print}"
 

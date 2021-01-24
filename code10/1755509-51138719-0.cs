    public sealed class IconImage
    {
        public Uri ImageUri { get; }
        public IconImage(Uri imageUri)
        {
            this.ImageUri = imageUri;
        }
        public static class ApplicationActions
        {
            public readonly IconImage Save = new IconImage(new Uri("foo"));
            public readonly IconImage Open = new IconImage(new Uri("foo"));
            public readonly IconImage Print = new IconImage(new Uri("foo"));
        }
        public static class Marks
        {
            public readonly IconImage Check = new IconImage(new Uri("foo"));
            public readonly IconImage Tickbox = new IconImage(new Uri("foo"));
            public readonly IconImage CheckedTickbox = new IconImage(new Uri("foo"));
        }
        // ...
    }
    // Usage: control.Icon = IconImage.Marks.TickBox;
    // XAML (without TypeConverter): Icon="{x:Static local:IconImage.Marks.TickBox}"
    // XAML (with TypeConverter): Icon="Marks.TickBox"

    public sealed class ContentDialogTest : ContentDialog
    {
        public ContentDialogTest()
        {
            this.DefaultStyleKey = typeof(ContentDialogTest);
        }
        public string PrimaryButtonGlyph
        {
            get => (string)GetValue(PrimaryButtonGlyphProperty);
            set => SetValue(PrimaryButtonGlyphProperty, value);
        }
    
        public string SecondaryButtonGlyph
        {
            get => (string)GetValue(SecondaryButtonGlyphProperty);
            set => SetValue(SecondaryButtonGlyphProperty, value);
        }
    
        public string CloseButtonGlyph
        {
            get => (string)GetValue(CloseButtonGlyphProperty);
            set => SetValue(CloseButtonGlyphProperty, value);
        }
    
        public static readonly DependencyProperty PrimaryButtonGlyphProperty = DependencyProperty.Register
                  (nameof(PrimaryButtonGlyph),
                   typeof(string),
                   typeof(ContentDialogTest),
                   new PropertyMetadata("&#xF13E;"));
    
        public static readonly DependencyProperty SecondaryButtonGlyphProperty = DependencyProperty.Register
            (nameof(SecondaryButtonGlyph),
            typeof(string), typeof(ContentDialogTest),
            new PropertyMetadata("&#xF13D;"));
    
        public static readonly DependencyProperty CloseButtonGlyphProperty = DependencyProperty.Register
                 (nameof(CloseButtonGlyph),
                  typeof(string),
                  typeof(ContentDialogTest),
                  new PropertyMetadata("&#xF13D;"));
    }

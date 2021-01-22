       public FontFamily FontFamily
            {
                get { return (FontFamily)GetValue(FontFamilyProperty); }
                set { SetValue(FontFamilyProperty, value); }
            }
    
     public static DependencyProperty FontFamilyProperty =
                DependencyProperty.Register(
                "FontFamily",
                typeof(FontFamily),
                typeof(YourClassVM),
                 new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily
            , FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

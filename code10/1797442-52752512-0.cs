    public abstract class TextElement : FrameworkContentElement, IAddChild
    {
        …
        /// <summary>
        /// DependencyProperty for <see cref="FontFamily" /> property.
        /// </summary>
        [CommonDependencyProperty]
        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.RegisterAttached(
                "FontFamily",
                typeof(FontFamily),
                typeof(TextElement),
                new FrameworkPropertyMetadata(
                    SystemFonts.MessageFontFamily,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |                 
                    FrameworkPropertyMetadataOptions.AffectsRender | 
                    FrameworkPropertyMetadataOptions.Inherits),
                    new ValidateValueCallback(IsValidFontFamily));

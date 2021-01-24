    public class Control : FrameworkElement
    {
        …
        /// <summary>
        ///     The DependencyProperty for the FontFamily property.
        ///     Flags:              Can be used in style rules
        ///     Default Value:      System Dialog Font
        /// </summary>
        [CommonDependencyProperty]
        public static readonly DependencyProperty FontFamilyProperty =
                TextElement.FontFamilyProperty.AddOwner(
                        typeof(Control),
                        new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily,
                            FrameworkPropertyMetadataOptions.Inherits));

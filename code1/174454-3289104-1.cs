    [DebuggerDisplay("{DebugDisplayText}")]
    [TypeConverter(typeof(DebugModuleConverter))]
    public class DebugModule : Module
    {
        public int FPS { get; set; }
        private string DebugDisplayText { get { return "FPS = " + FPS; } }
        public class DebugModuleConverter : ExpandableObjectConverter {
            public override object ConvertTo(ITypeDescriptorContext context,
                    System.Globalization.CultureInfo culture, object value,
                    Type destinationType) {
                if(destinationType == typeof(string)) {
                    return ((DebugModule) value).DebugDisplayText;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }

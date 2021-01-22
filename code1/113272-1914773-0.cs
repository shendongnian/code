    [MarkupExtensionReturnType(typeof(Array))]
    public class EnumValuesExtension : MarkupExtension
    {
        public EnumValuesExtension()
        {
        }
        public EnumValuesExtension(Type enumType)
        {
            this.EnumType = enumType;
        }
        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }

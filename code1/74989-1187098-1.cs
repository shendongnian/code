    enum Operation
    {
        [DisplayName("Equals")]
        Equals, 
        [DisplayName("Not Equals")]
        Not_Equals, 
        [DisplayName("Less Than")]
        Less_Than, 
        [DisplayName("Greater Than")]
        Greater_Than
    };
    public class OperationTypeConverter : TypeConverter
    {
        private static Dictionary<string, Operation> operationMap;
        static OperationTypeConverter()
        {
            BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.GetField
                | BindingFlags.Public;
            operationMap = enumType.GetFields(bindingFlags).ToDictionary(
                c => GetDisplayName(c)
                );
        }
        private static string GetDisplayName(FieldInfo field, Type enumType)
        {
            DisplayNameAttribute attr = (DisplayNameAttribute)Attribute.GetCustomAttribute(typeof(DisplayNameAttribute));
            return (attr != null) ? attr.DisplayName : field.Name;
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string stringValue = value as string;
            if (stringValue != null)
            {
                Operation operation;
                if (operationMap.TryGetValue(stringValue, out operation))
                {
                    return operation;
                }
                else
                {
                    throw new ArgumentException("Cannot convert '" + stringValue + "' to Operation");
                }
            }
        }
    }

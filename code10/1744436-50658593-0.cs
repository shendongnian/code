    public class EnumValuesExtension : MarkupExtension
    {
        private Type _enumType;
        private String _resourceName;
        private bool _addEmptyValue = false;
        // Enumeration type
        public Type EnumType
        {
            set { _enumType = value; }
        }
        // Name of the class of the .resx file        
        public String ResourceName
        {
            set { _resourceName = value; }
        }
        // Add empty value flag        
        public Boolean AddEmptyValue
        {
            set { _addEmptyValue = value; }
        }
        public EnumValuesExtension()
        {
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Enumeration type not passed through XAML
            if (_enumType == null)
                throw new ArgumentNullException("EnumType (Property not set)");
            if (!_enumType.IsEnum)
                throw new ArgumentNullException("Property EnumType must be an enum");
            // Bindable properties list
            List<dynamic> list = new List<dynamic>();
            if (!String.IsNullOrEmpty(_resourceName))
            {
                // Name of the resource class
                Type type = Type.GetType(_resourceName);
                if (type == null)
                    throw new ArgumentException(
                        "Resource name should be a fully qualified name");
                // We iterate through the Enum values
                foreach (var enumName in Enum.GetNames(_enumType))
                {
                    string translation = string.Empty;
                    var property = type.GetProperty(enumName,
                        BindingFlags.Static |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);
                    // If there's not translation for specific Enum value,
                    // there'll be a message shown instead
                    if (property == null)
                        translation = String.Format(
                            "Field {0} not found in the resource file {1}",
                            enumName,
                            _resourceName);
                    else
                        translation = property.GetValue(null, null).ToString();
                    list.Add(GetNamed(translation, enumName));
                }
                // Adding empty row
                if (_addEmptyValue)
                    list.Add(GetEmpty());
                return list;
            }
            // If there's no resource provided Enum values will be used
            // without translation
            foreach (var enumName in Enum.GetNames(_enumType))
                list.Add(GetNamed(enumName, enumName));
            if (_addEmptyValue)
                list.Add(GetEmpty());
            return list;
        }
        // Create one item which will fill our ComboBox ItemSource list
        private dynamic GetNamed(string translation, string enumName)
        {
            // We create a bindable context
            dynamic bindableResult = new ExpandoObject();
            // This dynamically created property will be
            // bindable from XAML (through DisplayMemberPath or wherever)
            bindableResult.Translation = translation;
            // We're setting the value, which will be passed to SelectedItem
            // of the ComboBox
            bindableResult.Enum = enumName;
            return bindableResult;
        }
        // Create one empty item which will fill our ComboBox ItemSource list
        private dynamic GetEmpty()
        {
            dynamic bindableResult = new ExpandoObject();
            bindableResult.Translation = String.Empty;
            bindableResult.Enum = null;
            return bindableResult;
        }
    }

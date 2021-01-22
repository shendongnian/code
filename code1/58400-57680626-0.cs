    public static class ControlExtensions
    {
        public static void BindToEnum<TEnum>(this ComboBox comboBox)
        {
            var enumType = typeof(TEnum);
            var fields = enumType.GetMembers()
                                  .OfType<FieldInfo>()
                                  .Where(p => p.MemberType == MemberTypes.Field)
                                  .Where(p => p.IsLiteral)
                                  .ToList();
            var valuesByName = new Dictionary<string, object>();
            foreach (var field in fields)
            {
                var descriptionAttribute = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                var value = (int)field.GetValue(null);
                var description = string.Empty;
                if (!string.IsNullOrEmpty(descriptionAttribute?.Description))
                {
                    description = descriptionAttribute.Description;
                }
                else
                {
                    description = field.Name;
                }
                valuesByName[description] = value;
            }
            comboBox.DataSource = valuesByName.ToList();
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
        }
    }

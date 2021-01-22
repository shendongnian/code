     public static void EnumForComboBox(this ComboBox comboBox, Type enumType)
        {
            var memInfo = enumType.GetMembers().Where(a => a.MemberType == MemberTypes.Field).ToList();
            comboBox.Items.Clear();
            foreach (var member in memInfo)
            {
                var myAttributes = member.GetCustomAttribute(typeof(DescriptionAttribute), false);
                var description = (DescriptionAttribute)myAttributes;
                if (description != null)
                {
                    if (!string.IsNullOrEmpty(description.Description))
                    {
                        comboBox.Items.Add(description.Description);
                        comboBox.SelectedIndex = 0;
                        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
               
            }
        }

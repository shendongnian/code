    enum MyEnum
    {
        [Description("Red Color")]
        Red = 10,
        [Description("Blue Color")]
        Blue = 50
    }
    ....
    
        private void LoadCombobox()
        {
            cmbxNewBox.DataSource = Enum.GetValues(typeof(MyEnum))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cmbxNewBox.DisplayMember = "Description";
            cmbxNewBox.ValueMember = "value";
        }

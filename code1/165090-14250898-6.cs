    public class ComboEnumItem {
        public string Text { get; set; }
        public object Value { get; set; }
        public ComboEnumItem(Enum originalEnum)
        {
            this.Value = originalEnum;
            this.Text = this.ToString();
        }
        public string ToString()
        {
            FieldInfo field = Value.GetType().GetField(Value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? Value.ToString() : attribute.Description;
        }
    }

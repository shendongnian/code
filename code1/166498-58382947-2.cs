    public static class DataBindingExtensions
    {
        public static string GetDescription(this Enum source)
        {
            var str = source.ToString();
            var fi = source.GetType().GetField(str);
            var desc = fi.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            return desc == null ? str : desc.Description; 
        }
        public static T GetValue<T>(this ComboBox comboBox)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            return (T)comboBox.SelectedValue;
        }
        
        public static ComboBox BindTo<T>(this ComboBox comboBox) 
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var list = Array.ConvertAll((T[])Enum.GetValues(typeof(T)), value => new { desp = ((Enum)(object)value).GetDescription(), value });
            comboBox.DataSource = list;
            comboBox.DisplayMember = "desp";
            comboBox.ValueMember = "value";
            return comboBox;
        }
        // C# 7.0 or highest
        public static ComboBox BindTo<T>(this ComboBox comboBox)
            where T : Enum
        {
            var list = Array.ConvertAll((T[])Enum.GetValues(typeof(T)), value => new { desp = value.GetDescription(), value });
            comboBox.DataSource = list;
            comboBox.DisplayMember = "desp";
            comboBox.ValueMember = "value";
            return comboBox;
        }
    }

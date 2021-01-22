    public static class EnumExtensions
    {
        public static string Description(this Enum source)
        {
            var str = source.ToString();
            var fi = source.GetType().GetField(str);
            var desc = fi.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            return desc == null ? str : desc.Description; 
        }
        
        public static ComboBox BindTo<T>(this ComboBox comboBox) 
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var list = Array.ConvertAll((T[])Enum.GetValues(typeof(T)), value => new { desp = ((Enum)(object)value).Description(), value });
            comboBox.DataSource = list;
            comboBox.DisplayMember = "desp";
            comboBox.ValueMember = "value";
            return comboBox;
        }
        // C# 7.0 or highest
        public static ComboBox BindTo<T>(this ComboBox comboBox)
            where T : Enum
        {
            var list = Array.ConvertAll((T[])Enum.GetValues(typeof(T)), value => new { desp = value.Description(), value });
            comboBox.DataSource = list;
            comboBox.DisplayMember = "desp";
            comboBox.ValueMember = "value";
            return comboBox;
        }
    }

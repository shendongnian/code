    class MyNumberArrayConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext ctx, Type type)
        { return (type == typeof(string)); }
        public override bool CanConvertFrom(ITypeDescriptorContext ctx, Type type)
        { return (type == typeof(string)); }
        public override object ConvertTo(ITypeDescriptorContext ctx, CultureInfo ci, object value, Type type)
        {
            MyNumberArray arr = value as MyNumberArray;
            StringBuilder sb = new StringBuilder();
            foreach (int i in arr)
                sb.Append(i).Append(',');
            return sb.ToString(0, Math.Max(0, sb.Length - 1));
        }
        public override object ConvertFrom(ITypeDescriptorContext ctx, CultureInfo ci, object data)
        {
            List<int> arr = new List<int>();
            if (data != null)
            {
                foreach (string txt in data.ToString().Split(','))
                    arr.Add(int.Parse(txt));
            }
            return new MyNumberArray(arr);
        }
    }

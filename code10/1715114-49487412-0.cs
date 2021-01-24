    using System;
    using System.ComponentModel;
    using System.Globalization;
    
    static class P
    {
        static void Main()
        {
            var foo = Foo.Gamma;
            var converter = TypeDescriptor.GetConverter(typeof(Foo));
            string s = converter.ConvertToString(foo);
            Console.WriteLine(s);
        }
    }
    
    [TypeConverter(typeof(FooConverter))]
    public enum Foo
    {
        Alpha, Beta, Gamma
    }
    class FooConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            // write it backwards, because: reasons
            if (destinationType == typeof(string)) {
                var s = value.ToString();
                char[] c = s.ToCharArray();
                Array.Reverse(c);
                return new string(c);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

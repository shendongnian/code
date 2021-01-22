    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form { Controls = {
                new DataGridView {
                    Dock = DockStyle.Fill,
                    DataSource = new List<MyClass> {
                        new MyClass { FooBar = "abc", Baz = 123.45M},
                        new MyClass { FooBar = "def", Baz = 678.90M}
                    }
                }
            }});
        }
    }
    class MyClass
    {
        [DisplayName("Foo/Bar")]
        public string FooBar { get; set; }
        [TypeConverter(typeof(CurrencyConverter))]
        public decimal Baz { get; set; }
    }
    class CurrencyConverter : DecimalConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            string s = value as string;
            if (s != null) return decimal.Parse(s, NumberStyles.Currency, culture);
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((decimal)value).ToString("C2", culture);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

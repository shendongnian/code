    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;
    public class FooTypeConverter : StringConverter {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new Foo("FooTypeConverter.ConvertFrom: " + Convert.ToString(value));
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "FooTypeConverter.ConvertTo: " + ((Foo)value).Value;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
    }
    [TypeConverter(typeof(FooTypeConverter))]
    class Foo
    {
        public string Value { get; set; }
        public Foo(string value) { Value = value; }
    
        public override string ToString()
        {
            return "Foo.ToString";
        }
    }
    class Test
    {
        public Foo Foo { get; set; }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using(Form form = new Form())
            using (PropertyGrid grid = new PropertyGrid())
            {
                grid.Dock = DockStyle.Fill;
                grid.SelectedObject = new Test { Foo = new Foo("Main") };
                form.Controls.Add(grid);
                Application.Run(form);
            }
        }
    }

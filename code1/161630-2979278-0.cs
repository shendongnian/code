    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class MyObject
    {
        [TypeConverter(typeof(MyConverter))]
        public decimal SomeValue { get; set; }
    }
    
    class MyConverter : TypeConverter {
        public override object  ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if(destinationType == typeof(string)) {
                return "Our survery says: " + value + "%";
            }
     	     return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    static class Program {
        [STAThread]
        static void Main() {
            using(var form = new Form()) {
                form.DataBindings.Add("Text",new MyObject { SomeValue = 27.1M}, "SomeValue", true);
                Application.Run(form);
            }
        }
    }

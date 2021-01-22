    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Forms;
    
    class Person
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    
        [TypeConverter(typeof(MyDateTimeConverter))]
        public DateTime EditableValue { get { return ActualValue; } set { ActualValue = value; } }
        // this just proves what we have set...
        public DateTime ActualValue { get; private set; }
    }
    class MyDateTimeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }
        const string FORMAT = "dd MMM yyyy";
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value != null && value is string)
            {
                string s = (string)value;
                return DateTime.ParseExact(Reverse(s), FORMAT, CultureInfo.InvariantCulture);
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return Reverse(((DateTime)value).ToString(FORMAT, CultureInfo.InvariantCulture));
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        static string Reverse(string value)
        {
            char[] data = value.ToCharArray();
            Array.Reverse(data);
            return new string(data);
        }
    }
    class MyForm : Form
    {
        public MyForm()
        {
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            List<Person> people = new List<Person>();
            people.Add(new Person { Forename = "Fred", Surname = "Flintstone", EditableValue = DateTime.Today });
            people.Add(new Person { Forename = "Barney", Surname = "Rubble", EditableValue = DateTime.Today.AddDays(-25) });
            grid.DataSource = people;
            Controls.Add(grid);
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
    }

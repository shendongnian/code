    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class MyData
    {
        [TypeConverter(typeof(MyConverter))]
        public string Bar { get; set; }
        public string[] Options { get; set; }
    }
    class MyConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MyData data = (MyData)context.Instance;
            if(data == null || data.Options == null) {
                return new StandardValuesCollection(new string[0]);
            }
            return new StandardValuesCollection(data.Options);
        }
    }
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form
            {
                Controls =
                {
                    new PropertyGrid {
                        Dock = DockStyle.Fill,
                        SelectedObject = new MyData()
                    }
                }
            });
        }
    }

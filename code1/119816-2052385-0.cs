    using System.Windows.Forms;
    using System;
    using System.Linq;
    using System.ComponentModel;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Data data = new Data { Name = "the name", Value = "the value" };
            using (Form form = new Form
            {
                Controls =
                {
                    new PropertyGrid {
                        Dock = DockStyle.Fill,
                        SelectedObject = data
                    },
                    new TextBox {
                        Dock = DockStyle.Bottom,
                        DataBindings = { {"Text", data, "Value"}, }
                    },
                    new TextBox {
                        Dock = DockStyle.Bottom,
                        DataBindings = { {"Text", data, "Name"}, }
                    }
                }
            })
            {
                Application.Run(form);
            }        
        }
    }
    [TypeConverter(typeof(DataConverter))]
    class Data
    {
        class DataConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                var props = base.GetProperties(context, value, attributes);
                return new PropertyDescriptorCollection(
                    (from PropertyDescriptor prop in props
                     where prop.Name != "Value"
                     select prop).ToArray(), true);
            }
        }
        public string Value { get; set; }
        public string Name { get; set; }
    }

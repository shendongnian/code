    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System;
    class TestConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes)
        {
            PropertyDescriptorCollection orig = base.GetProperties(context, value, attributes);
            List<PropertyDescriptor> list = new List<PropertyDescriptor>(orig.Count);
            string propsToInclude = "Foo|Blop"; // from config
            foreach (string propName in propsToInclude.Split('|'))
            {
                PropertyDescriptor prop = orig.Find(propName, true);
                if (prop != null) list.Add(prop);
            }
            return new PropertyDescriptorCollection(list.ToArray());
        }
    }
    [TypeConverter(typeof(TestConverter))]
    class Test
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Blop { get; set; }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Test test = new Test { Foo = "foo", Bar = "bar", Blop = "blop"};
            using (Form form = new Form())
            using (PropertyGrid grid = new PropertyGrid())
            {
                grid.Dock = DockStyle.Fill;
                form.Controls.Add(grid);
                grid.SelectedObject = test;
                Application.Run(form);
            }
        }
    }

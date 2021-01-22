    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    
    class Foo
    {
        public Foo() { Bar = new Bar(); }
        public Bar Bar { get; set; }
    }
    class Bar
    {
        public string Value { get; set; }
    }
    
    class BarEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            MessageBox.Show("Editing!");
            return base.EditValue(context, provider, value);
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            TypeDescriptor.AddAttributes(typeof(Bar),
                new EditorAttribute(typeof(BarEditor), typeof(UITypeEditor)));
            Application.EnableVisualStyles();
            Application.Run(new Form { Controls = { new PropertyGrid { SelectedObject = new Foo() } } });
        }
    }

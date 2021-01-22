    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    class Foo
    {
        [TypeConverter(typeof(PasswordConverter))]
        [Editor(typeof(PasswordEditor), typeof(UITypeEditor))]
        public string Password { get; set; }
    
        // just to show for debugging...
        public string PasswordActual { get { return Password; } }
    }
    class PasswordConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            return destinationType == typeof(string) ? "********" : 
                base.ConvertTo(context, culture, value, destinationType);
            
            
        }
    }
    class PasswordEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null) {
                TextBox tb;
                Button btn;
                Form frm = new Form { Controls = {
                     (tb = new TextBox { PasswordChar = '*', Dock = DockStyle.Top,
                         Text = (string)value}),
                     (btn = new Button { Text = "OK", Dock = DockStyle.Bottom, DialogResult = DialogResult.OK})
                }, AcceptButton = btn};
    
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    value = tb.Text;
                }
            }
            return value;
        }
    }
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form {
                Controls = {
                    new PropertyGrid {
                        Dock = DockStyle.Fill,
                        SelectedObject = new Foo { Password = "Bar"}
                    }
                }
            });
        }
    }

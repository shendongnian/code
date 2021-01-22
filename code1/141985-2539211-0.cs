    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    class MyData
    {
        [Editor(typeof(MyEditor), typeof(UITypeEditor))]
        public string Bar { get; set; }
    
        public string[] Options { get; set; }
    }
    class MyEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // break point here; inspect context
            return base.GetEditStyle(context);
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

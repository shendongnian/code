    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyControlDesigner))]
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
        void InitializeComponent() { }
        public Color SomeColorProperty { get; set; }
        public string[] Items { get; set; }
    }

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            Fruits = new List<Fruit>();
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Fruit> Fruits { get; private set; }
    }

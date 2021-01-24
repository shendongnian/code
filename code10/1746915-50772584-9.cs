    [Designer(typeof(MyUserControlDesigner))]
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            TypeDescriptor.AddAttributes(this.panel1,
                new DesignerAttribute(typeof(MyPanelDesigner)));
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentsPanel
        {
            get { return panel1; }
        }
    }

    public partial class FormB: Form
    {
        public FormCtrl Reference { get; set; }
        public FormB(FormCtrl referencedForm)
        {
            InitializeComponent();
            Reference = referencedForm;
            Reference.Panel2.Visible = true;
        }
    }

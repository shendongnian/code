    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            myMenu.Visible = CheckUserRole();	
        }
    }
    public partial class MyForm : BaseForm
    {
        public MyForm() : base()
        {
            InitializeComponent();
        }
    }

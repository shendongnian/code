    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            button1.Visible = DateTime.Now.Millisecond % 2 == 0;
        }
    }
    public partial class MyForm : WindowsFormsApp7.BaseForm
    {
        public MyForm() : base()
        {
            InitializeComponent();
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            button3.Visible = !button1.Visible;
        }
    }

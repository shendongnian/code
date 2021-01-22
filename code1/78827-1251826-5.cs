    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        private void ButtonOpenClick(object sender, EventArgs e)
        {
            ChildForm form = new ChildForm(this);
            form.Show();
        }
    }

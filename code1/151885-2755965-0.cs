    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
            Load += ParentLoad;
        }
        private void ParentLoad(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

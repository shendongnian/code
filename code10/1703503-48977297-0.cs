    public partial class Newuserform : Form
    {
        //the public property
        public event EventHandler<string> UnameChanged;
        public Newuserform()
        {
            InitializeComponent();
        }
        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
             if (UnameChanged != null)
                 UnameChanged(textboxUsername.ToString()); //fire the event
        }
    }

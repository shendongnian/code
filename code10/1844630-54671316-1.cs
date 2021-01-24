    public partial class Phonebook : Form
    {
        private void AddContact_Click(object sender, EventArgs e)
        {
            MakeContact MC = new MakeContact(this);
            MC.Show();
        }
    
        public void AddContacts(string Name)
        {
            Label name = new Label();
            // (...)
            this.Controls.Add(name);
        }
    }
    public partial class MakeContact : Form
    {
        private PhoneBook pBook = null;
        public MakeContact() : this(null) { }
        public MakeContact(PhoneBook phoneBook)
        {
            InitializeComponent();
            this.pBook = phoneBook;
        }
    
        private void FinishContact_Click(object sender, EventArgs e)
        {
            string Name = FullName.Text;
            this.pBook?.AddContacts(Name);
            this.Close();
        }
    }

    public partial class MyDerivedForm : SingletonMadness.PersonForm
    {
        public MyDerivedForm(Person person)
            : base(person)
        {
            InitializeComponent();
        }
    
        private void MyDerivedForm_Load(object sender, EventArgs e)
        {
            label1.Text = this.MyPerson.Name;
        }
    }

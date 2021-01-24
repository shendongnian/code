    public partial class Form1 : Form
    {
        private BindingList<Person> people = new BindingList<Person>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = people;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            people.Add(new Person("Humza"));
            people.ResetBindings();
        }
    }

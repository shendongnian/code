    public partial class Form1 : Form
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }
        List<Person> _People;
        public Form1()
        {
            InitializeComponent();
            _People = new List<Person>();
            _People.Add(new Person() { FirstName = "John", LastName = "Smith", PhoneNumber = "123-456-7890" });
            _People.Add(new Person() { FirstName = "Jane", LastName = "Doe", PhoneNumber = "098-765-4321" });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("barcode.png");
            pictureBox1.Location = new Point(-1000, -1000);
            dataGridView1.DataSource = _People;
            dataGridView1.Location = new Point(-1000, -1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PopupControl popup = new PopupControl(pictureBox1);
            popup.Show(new Point(this.Location.X - 128, this.Location.Y));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PopupControl popup = new PopupControl(dataGridView1);
            popup.Show(new Point(this.Location.X - 128, this.Location.Y));
        }
    }

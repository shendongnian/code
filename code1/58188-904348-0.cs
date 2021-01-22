    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<People> lPeople = new List<People> 
            {
                new People { Name= "Jean", LastName = "Borrow", Age= 21 } ,
                new People { Name= "Dean", LastName = "Torrow", Age= 20 }
            };
            IEnumerable<People> result = lPeople.Where(p => p.Name == textBox1.Text);
            dgv_1.DataSource = result.ToList();
            dgv_1.Update();
        }
    }    
    public class People
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    namespace WindowsFormsApp1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Human
        {
            public string Name;
            public Human(string name)
            {
                Name = name;
            }
        }
		List<Human> objHumanList;
        private void Form1_Load(object sender, EventArgs e)
        {
			objHumanList=new List<Human>();
            textBox1.Text = "Jane";
        }
        private void AddNewHuman_Click(object sender, EventArgs e)
        {
            Human h1 = new Human(textBox1.Text);
			objHumanList.add(h1);
			
			/** Or
			
			objHumanList.add (new Human(textBox1.Text))
			
			**/
        }
    }
    }

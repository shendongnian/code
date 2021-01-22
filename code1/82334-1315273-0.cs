     public partial class Form1 : Form
        {
            public Action[] actions = new Action[]
                {
    new Action() { name = "foo", value = 1 },
    new Action() { name = "bar", value = 2 },
    new Action() { name = "foobar", value = 3 }
                };
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.Items.AddRange(actions);
            }
    
        }
    
        public class Action
        {
            public string name;
            public int value;
            public override string ToString()
            {
                return name;
            }
        }

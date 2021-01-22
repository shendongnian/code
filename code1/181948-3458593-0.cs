    public string firstName;
    namespace doomsday
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
               
    
            }
           public void whenTextbox1LoseFocus {
                var greet = new doomsday();
                greet.firstname = textBox1.Text;
                textbox2.text = greet.DisplayGreeting()
            }
    
        }
    }

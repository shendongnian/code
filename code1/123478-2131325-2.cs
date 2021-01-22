    public partial class Form1 : Form
    {
        List<String> mylistSource;
        public Form1()
        {
            InitializeComponent();
            mylistSource = new List<string>();
            // populate source with test data
            for (int i = 0; i < 25; i++)
			{
                mylistSource.Add(i.ToString());
			}
            //assign source to both lists
            listBox1.DataSource = mylistSource;
            listBox2.DataSource = mylistSource;
        }
    }

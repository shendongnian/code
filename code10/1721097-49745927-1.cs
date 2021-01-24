    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public void something(string str)
            {
                 another_function(str);
            }
            public void another_function(string str)
            {
                label1.Text = str;
            }
        }

    public partial class Form1 : Form
    {
        // Add a string argument to the form's constructor. 
        // If it's not empty, we'll use it for the form's title.
        public Form1(string input)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(input)) this.Text = input;
         }
    }

    public partial class Form1 : Form
    {
        //Declare private list of type string as class property, this maintains
        //scope in all methods of class object
        private List<string> inputList;
        public Form1()
        {
            InitializeComponent();
            label1.Text = String.Empty;
            //Initialize your list
            this.inputList = new List<string>();
        }

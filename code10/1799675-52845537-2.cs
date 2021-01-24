    public partial class Form2 : Form
    {
        //you can expand your own custom event, string strText can be Control, DataSet, etc
        public delegate void TextChangeHappen(string strText); //my custom delegate
        public event TextChangeHappen OnUserSelectNewText;     //my custom event
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // to prevent null ref exception, if there is no event handler.
            if (OnUserSelectNewText != null) 
            {
                OnUserSelectNewText(this.comboBox1.Text);
            }
            this.Close();
        }
    }

    public partial class Form1 : Form
    {
        TextBox txt;
        string val;
        public Form1()
        {
            InitializeComponent();
            txt = (TextBox)numericUpDown1.Controls[1];//notice the textbox is the 2nd control in the numericupdown control
            txt.TextChanged += new EventHandler(txt_TextChanged);
            txt.Validating += new CancelEventHandler(txt_Validating);
        }
    
        void txt_TextChanged(object sender, EventArgs e)
        {
            if (txt.Focused) //don't save the value unless the textbox is focused, this is the new trick
                val = txt.Text;
        }
        void txt_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Val: " + val);
        }
    }

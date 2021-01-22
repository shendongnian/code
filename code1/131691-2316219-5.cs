    public partial class Form1 : Form
    {
        TextBox txt;
        string val;
        public Form1()
        {
            InitializeComponent();
            txt = (TextBox)numericUpDown1.Controls[1];
            txt.TextChanged += new EventHandler(txt_TextChanged);
            txt.Validating += new CancelEventHandler(txt_Validating);
        }
    
        void txt_TextChanged(object sender, EventArgs e)
        {
            if (txt.Focused)
                val = txt.Text;
        }
        void txt_Validating(object sender, CancelEventArgs e)
        {
            int enteredVal = 0;
            int.TryParse(val, out enteredVal);
            if (enteredVal > numericUpDown1.Maximum || enteredVal < numericUpDown1.Minimum)
            {
                txt.Text = val;
                e.Cancel = true;
            }
        }
    }

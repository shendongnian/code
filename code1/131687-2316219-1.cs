    public partial class Form1 : Form
        {
            TextBox txt;
            public Form1()
            {
                InitializeComponent();
                txt = (TextBox)numericUpDown1.Controls[1];//notice the textbox is the 2nd control in the numericupdown control
                txt.Validating += new CancelEventHandler(txt_Validating);
            }
            void txt_Validating(object sender, CancelEventArgs e)
            {
                this.Text = txt.Text;
            }
        }

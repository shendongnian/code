    public partial class Form1 : Form
    {
        int i = 1;
        int j = 1;
        int rbCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonAddRadio_Click(object sender, EventArgs e)
        {
            RadioButton rb = new RadioButton();
            rb.Name = "Radio Button" + i.ToString();
            rb.Text = "Radio Button" + i;
            rb.Left = 8;
            rb.Top = 15 + (rbCount * 27);
            rb.AutoSize = true;
            rb.Click += new EventHandler(radio_click);
            groupBox1.Controls.Add(rb);
            i++;
            rbCount++;
        }
        void radio_click(object sender, EventArgs e)
        {
            MessageBox.Show(((RadioButton)sender).Text);
        }
        private void buttonAddCheck_Click(object sender, EventArgs e)
        {
            CheckBox cb = new CheckBox();
            cb.Name = "CheckBox" + j.ToString();
            cb.Text = "CheckBox" + j;
            cb.Left = 8;
            cb.Top = 15 + (rbCount * 27);
            cb.AutoSize = true;
            cb.Click += new EventHandler(checkbox_checked);
            groupBox1.Controls.Add(cb);
            j++;
            rbCount++;
        }
        void checkbox_checked(object sender, EventArgs e)
        {
            MessageBox.Show(((CheckBox)sender).Text);
        }
    }

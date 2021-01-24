    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.Items.Add("Attendee");
                comboBox1.Items.Add("HOD");
                comboBox1.Items.Add("Driver");
                comboBox1.Items.Add("FD");
            }
        }
    }

    namespace HideForm1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Shown(object sender, EventArgs e)
            {
                try
                {
                    string defpassword = "1234"; //your default password
                    string passwordfromfile = "1234"; //password you are reading from .txt file
    
                    if (passwordfromfile == defpassword)
                    {
                        Form2 objForm2 = new Form2();
                        Hide();
                        objForm2.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception caught: " + ex.Message);
                }
              
            }
        }
    }

    namespace WindowsFormsApp1
    {
        public partial class Main : Form
        {
            public Main()
            {
                InitializeComponent();
            }        
            List<Form> formAction;
            private void runbtn_Click(object sender, EventArgs e)
            {            
                if (formAction == null)
                {
                    formAction = new List<Form>() {
                    new Form2(), new Form2(), new Form2(), new Form2(), new Form2(),
                    new Form2(), new Form2(), new Form2(), new Form2(), new Form2()
                    };
                    foreach (var form in formAction)
                    {
                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Form already open!");
                }                     
            }
            private void stopbtn_Click(object sender, EventArgs e)
            {
                if (formAction == null)
                {
                    MessageBox.Show("It's already close!");
                }
                else
                {
                    foreach (var form in formAction)
                    {
                        form.Close();
                        formAction = null;
                    }
                }            
            }        
        }
    }

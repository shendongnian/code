    public partial class MyForm : Form
    {        
        public MyForm()
        {
            if (MyFunc())
            {
                this.Load += MyForm_CloseOnStart;
            }
        }
        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
    }

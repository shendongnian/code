    public MyForm : Form
    {
        private UserControl _userControl = null;
        ...
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_userControl == null)
                //make control
            //set control data
        }
    }

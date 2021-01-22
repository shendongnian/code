    private void textbox1_Validating(object sender, CancelEventArgs e)
    {
        try
        {
            int numberEntered = int.Parse(Textbox1.Text);
            if (numberEntered > 2147483647)
            {
                e.Cancel = true;
                MessageBox.Show("You have to enter number up to 2147483647");
            }
        }
        catch (FormatException)
        {
            e.Cancel = true;
            MessageBox.Show("You need to enter a valid integer");
        }
    }
        private void InitializeComponent()
        {
    
            // 
            // more code
            // 
            this.Textbox1.Validating += new System.ComponentModel.CancelEventHandler(this.textbox1_Validating);
        }

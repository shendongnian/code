    // Add this in the Form Initialization or Form_Load()
    boxOptions.SelectedIndexChanged += new 
     system.EventHandler(boxOptions_SelectedIndexChanged);
    
    // Event Handler
    private void boxOptions_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        txtBox1.Text = comboBox_Code1.Text;
    }

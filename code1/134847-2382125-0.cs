    protected void ButtonReset_Click(object sender, EventArgs e) {
        if (!TextBox1.Enabled || !ButtonSubmit.Enabled) {
            TextBox1.Enabled = true;
            ButtonSubmit.Enabled = true;
        }
        VieStateData.ResetSession(); // Created a dedicated class to handle the data and session state
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        
        // More controls to modify
     }

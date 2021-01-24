    // Button click event
    private void button1_Click(object sender, EventArgs e)
    {
        // Focus on textbox
        this.ActiveControl = textBox1;
    }
    // Form load event
    private void Form1_Load(object sender, EventArgs e)
    {
        // Focus on textbox
        this.ActiveControl = textBox1;
    }
    // Close the current form and open another one. Use any event what you want
    private void button1_Click(object sender, EventArgs e)
    {
        using (Form2 frm = new Form2())
        {
            // Hide the current form. If you close it it will dispose all further events
            this.Hide();
            
            // Open the new form
            frm.Show();
            
            // Close the current form
            this.Close();
        }
    }
    

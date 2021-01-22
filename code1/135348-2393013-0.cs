    private void textBox1_TextChanged(object sender, EventArgs e)
    {
          if(String.IsNullOrEmpty(textBox1.Text))
          {
                button15.Enabled = false;
                button16.Enabled = false;
          }
          else
          {
                button15.Enabled = true;
                button16.Enabled = true;
          }
    }

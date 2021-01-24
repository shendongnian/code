    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       if (lb.SelectedIndex == -1)
       {
         button1.Enabled = false;
       }
       else 
       {
         button1.Enabled = true;
       }
    }

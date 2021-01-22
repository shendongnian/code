    private void button1_Click(object sender, EventArgs e)
    {
        using (frmCustomDialog f = new frmCustomDialog())
        {
            if(f.ShowDialog() == DialogResult.OK)
            {
                TextBox1.Text = f.MyCustomProperty;
            }
        }
    }

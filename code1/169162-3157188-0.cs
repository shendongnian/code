    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        int i;
        if (int.TryParse(e.KeyChar.ToString(), out i))
        {
            MessageBox.Show("Number");
        }
    }

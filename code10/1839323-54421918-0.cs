    private void textBox4_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            //...
            conn.Close();
            textBox4.Text=" ";
        }
    }

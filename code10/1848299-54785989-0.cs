    private int attempts = 0;
    private void btn_login_Click(object sender, EventArgs e)
    {
        int pin_number;
        pin_number = int.Parse(txt_pin.Text);
        MessageBox.Show("Hi There");
        if (attempts < 3 && pin_number != 1326)
        {
            attempts++;
            MessageBox.Show($"pin code is incorrect you have {attempts} of 3 attempts left");
            txt_pin.Text = "";
            txt_pin.Focus();
        }
    }

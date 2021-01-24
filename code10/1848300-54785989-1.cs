    private int attempts = 3;
    private void btn_login_Click(object sender, EventArgs e)
    {
        int pin_number;
        pin_number = int.Parse(txt_pin.Text);
        MessageBox.Show("Hi There");
        if (attempts <= 0)
        {
            MessageBox.Show($"No more attempts left");
        }
        else if (pin_number != 1326)
        {
            attempts--;
            MessageBox.Show($"Pin code is incorrect you have {attempts} attempts left");
            txt_pin.Text = "";
            txt_pin.Focus();
        }
    }
